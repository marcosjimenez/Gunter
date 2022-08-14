using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Infrastructure.Helpers
{
    public class SourceCodeItem<TIn, TOut>
    {
        public object Parent { get; set; } = new();
        public TIn Parameter { get; set; } = default;
        public List<string> Usings { get; set; } = new();
        public string NameSpace { get; set; } = "Gunter.IsolatedNamespace";
        public List<string> PreClassNameSource { get; set; } = new();
        public string ClassName { get; set; } = "GunterDummyClass";
        public string MethodName { get; set; } = "GunterMethod";
        public List<string> Source { get; set; } = new();
        public List<string> RefPaths { get; set; } = new();

        public Type ReturnType { get; set; } = typeof(object);
        public Type InputType { get; set; } = typeof(object);

        public List<string> SearchDirectories { get; set; } = new();

        public SourceCodeItem()
        {
            this.AddRefSearchPath(GetType().GetTypeInfo().Assembly.Location);
            this.AddRefSearchPath(typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location);
            this.AddRefSearchPath(typeof(object).GetTypeInfo().Assembly.Location);

            this.AddRefPath(new[] {
                typeof(System.Object).GetTypeInfo().Assembly.Location,
                this.GetType().GetTypeInfo().Assembly.Location,
                Path.Combine(Path.GetDirectoryName(typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location), "System.Runtime.dll")
            });
        }
    }

    public static class SourceCodeItemExtensions
    {
        public static SourceCodeItem<TIn, TOut> AddUsing<TIn, TOut>(this SourceCodeItem<TIn, TOut> item, string newUsing)
        {
            item.Usings.Add($"using {newUsing};");
            return item;
        }

        public static SourceCodeItem<TIn, TOut> AddPreClassNameSource<TIn, TOut>(this SourceCodeItem<TIn, TOut> item, string[] code)
        {
            item.PreClassNameSource.AddRange(code.ToList());
            return item;
        }

        public static SourceCodeItem<TIn, TOut> AddSource<TIn, TOut>(this SourceCodeItem<TIn, TOut> item, string[] code)
        {
            item.Source.AddRange(code.ToList());
            return item;
        }

        public static SourceCodeItem<TIn, TOut> AddRefSearchPath<TIn, TOut>(this SourceCodeItem<TIn, TOut> item, string searchPath)
        {
            var path = Path.GetDirectoryName(searchPath);
            if (Directory.Exists(path) && !item.SearchDirectories.Contains(path))
                item.SearchDirectories.Add(path);

            return item;
        }

        public static SourceCodeItem<TIn, TOut> AddRefPath<TIn, TOut>(this SourceCodeItem<TIn, TOut> item, string[] refs)
        {
            foreach(var reference in refs)
            {
                var newItem = GetFullPathForRef(reference);
                if (!string.IsNullOrWhiteSpace(newItem))
                    item.RefPaths.Add(GetFullPathForRef(reference));
            }
            return item;
        }

        public static SourceCodeItem<TIn, TOut> AddRefPathsForName<TIn, TOut>(this SourceCodeItem<TIn, TOut> item, string name)
        {
            foreach(var dir in item.SearchDirectories)
            {
                var files = Directory.GetFiles(dir, $"{name}*.dll");
                foreach(var file in files)
                    item.RefPaths.Add(file);
            }

            return item;
        }

        private static string GetFullPathForRef(Type type)
        {
            var location = type.GetTypeInfo().Assembly.Location;
            return File.Exists(location) ? location : string.Empty;
        }

        private static string GetFullPathForRef(string reference)
        {
            var file = Path.Combine(Path.GetDirectoryName(typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location), $"{reference}.dll");
            return File.Exists(file) ? file : string.Empty;
        }
    }
}
