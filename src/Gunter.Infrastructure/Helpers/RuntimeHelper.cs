using Gunter.Core.Infrastructure.Log;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Gunter.Core.Infrastructure.Helpers
{
    public class RuntimeHelper
    {
        /// <summary>
        /// https://github.com/joelmartinez/dotnet-core-roslyn-sample/blob/master/Program.cs
        /// </summary>
        /// 
        public virtual TOut CompileAndRun<TIn, TOut>(SourceCodeItem<TIn, TOut> item)
        {
            try
            {
                return compileAndRun(item);
            }
            catch(Exception ex)
            {
                var exception = ex;
                do
                {
                    GunterLog.Instance.Log("CompileAndRun", $"{exception.Message}\n{exception.StackTrace}", GunterLogItem.GunterLogItemSeverity.Error);
                    exception = exception.InnerException;
                } while (exception is not null);
            }

            return default(TOut);
        }

        private TOut compileAndRun<TIn, TOut>(SourceCodeItem<TIn, TOut> item)
        {

            var code = GenerateClassForSource(item);
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

            string assemblyName = Path.GetRandomFileName();

            item.AddRefPathsForName("System.Runtime");
            item.AddRefPathsForName("mscorlib");
            item.AddRefPathsForName("netstandard");
            item.AddRefPathsForName("System.Private.CoreLib");
            item.AddRefPathsForName("System.Collections");
            var references = item.RefPaths.Select(r => MetadataReference.CreateFromFile(r)).ToList();
            var currentAssemby = Assembly.GetExecutingAssembly();
            var basePath = Path.GetDirectoryName(currentAssemby.Location);
            foreach (var assembly in currentAssemby.GetReferencedAssemblies())
            {
                var file = $"{Path.Combine(basePath, assembly.Name)}.dll";
                if (File.Exists(file))
                    references.Add(MetadataReference.CreateFromFile(file));
            }

            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: new[] { syntaxTree },
                references: references.ToArray(),
                options: new CSharpCompilationOptions (outputKind: OutputKind.DynamicallyLinkedLibrary));

            using var ms = new MemoryStream();

            EmitResult result = compilation.Emit(ms);

            if (!result.Success)
            {
                IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                    diagnostic.IsWarningAsError ||
                    diagnostic.Severity == DiagnosticSeverity.Error);

                var sb = new StringBuilder();
                foreach (Diagnostic diagnostic in failures)
                {
                    var error = $"\t{diagnostic.Id}: {diagnostic.GetMessage()}";
                    GunterLog.Instance.Log("RuntimeHelper", error);
                    sb.AppendLine(error);
                }

                throw new InvalidOperationException(sb.ToString());
            }
            else
            {
                ms.Seek(0, SeekOrigin.Begin);

                Assembly assembly = AssemblyLoadContext.Default.LoadFromStream(ms);
                var type = assembly.GetType($"{item.NameSpace}.{item.ClassName}");
                var instance = assembly.CreateInstance($"{item.NameSpace}.{item.ClassName}");
                var meth = type.GetMember(item.MethodName).First() as MethodInfo;
                var executionResult = (TOut)meth.Invoke(instance, new object[] { item.Parameter });

                return executionResult;
            }
        }

        public virtual string GenerateMethodHeader<TIn, TOut>(string methodName = "GunterMethod", Type? inputType = null, Type? returnType = null)
        => string.Concat(
            string.Format("public {0} {1} ({2} parameter)",
                (returnType?.Name) ?? typeof(TOut).Name, // return type first
                methodName,
                (inputType?.Name) ?? typeof(TIn).Name),
            "{");

        public virtual string GenerateUsings()
        => @"
            using System;";

        public virtual string GenerateNamespace(string nameSpace)
        => @"
            namespace " + nameSpace + @"
            {    ";

        public virtual string GenerateClassHeader(string className)
        => @"
            public class " + className + @"
            {";

        public virtual string GenerateCloseTag()
        => @"
            }";

        public virtual string GenerateClassForSource<TIn, TOut>(SourceCodeItem<TIn,TOut> sourceItem)
        {
            var sb = new StringBuilder(GenerateUsings());
            foreach (var item in sourceItem.Usings)
                sb.AppendLine(item);

            sb.AppendLine(GenerateNamespace(sourceItem.NameSpace));

            foreach (var item in sourceItem.PreClassNameSource)
                sb.AppendLine(item);

            sb.AppendLine(GenerateClassHeader(sourceItem.ClassName));

            sb.AppendLine(GenerateMethodHeader<TOut, TIn>(sourceItem.MethodName, sourceItem.InputType, sourceItem.ReturnType));

            foreach (var line in sourceItem.Source)
                sb.AppendLine(line);

            sb.AppendLine(GenerateCloseTag()); // method 
            sb.AppendLine(GenerateCloseTag()); // class
            sb.AppendLine(GenerateCloseTag()); // namespace

            return sb.ToString();
        }
    }
}
