using System.Reflection.Emit;
using System.Reflection;

namespace Gunter.Core.Infrastructure.Helpers
{
    public class RuntimeCreationHelper
    {
        private static readonly Lazy<RuntimeCreationHelper> lazy = new(() => new RuntimeCreationHelper());
        public static RuntimeCreationHelper Instance { get => lazy.Value; }
        public Type GeneratedType { private set; get; } = typeof(object);

        private Dictionary<string, Type> generatedTypes = new();
        public Dictionary<string, Type> GetGeneratedTypeList { get => generatedTypes; }

        private RuntimeCreationHelper()
        {

        }

        public bool GenerateType(Dictionary<string, Type> properties, out Type? generatedType)
        {
            var newTypeName = Guid.NewGuid().ToString();
            var assemblyName = new AssemblyName(newTypeName);
            var dynamicAssembly = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var dynamicModule = dynamicAssembly.DefineDynamicModule("Main");
            var dynamicType = dynamicModule.DefineType(newTypeName,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null);     // This is the type of class to derive from. Use null if there isn't one
            dynamicType.DefineDefaultConstructor(MethodAttributes.Public |
                                                MethodAttributes.SpecialName |
                                                MethodAttributes.RTSpecialName);
            foreach (var property in properties)
                AddProperty(dynamicType, property.Key, property.Value);

            try
            {
                generatedType = dynamicType.CreateType();
            }
            catch
            {
                generatedType = default;
                return false;
            }

            if (generatedType is not null)
                GetGeneratedTypeList.Add(newTypeName, generatedType);

            return true;
        }

        public bool GenerateType<T>(out Type? generatedType)
        {
            Dictionary<string, Type> _properties = new();

            var newTypeName = Guid.NewGuid().ToString();
            var assemblyName = new AssemblyName(newTypeName);
            var dynamicAssembly = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var dynamicModule = dynamicAssembly.DefineDynamicModule("Main");
            var dynamicType = dynamicModule.DefineType(newTypeName,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    typeof(T));     // This is the type of class to derive from. Use null if there isn't one
            dynamicType.DefineDefaultConstructor(MethodAttributes.Public |
                                                MethodAttributes.SpecialName |
                                                MethodAttributes.RTSpecialName);
            foreach (var property in _properties)
                AddProperty(dynamicType, property.Key, property.Value);

            try
            {
                generatedType = dynamicType.CreateType();
            }
            catch
            {
                generatedType = default;
                return false;
            }

            if (generatedType is not null)
                GetGeneratedTypeList.Add(newTypeName, generatedType);

            return true;
        }

        private static void AddProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
        {
            var fieldBuilder = typeBuilder.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);
            var propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);

            var getMethod = typeBuilder.DefineMethod("get_" + propertyName,
                MethodAttributes.Public |
                MethodAttributes.SpecialName |
                MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            var getMethodIL = getMethod.GetILGenerator();
            getMethodIL.Emit(OpCodes.Ldarg_0);
            getMethodIL.Emit(OpCodes.Ldfld, fieldBuilder);
            getMethodIL.Emit(OpCodes.Ret);

            var setMethod = typeBuilder.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });
            var setMethodIL = setMethod.GetILGenerator();
            Label modifyProperty = setMethodIL.DefineLabel();
            Label exitSet = setMethodIL.DefineLabel();

            setMethodIL.MarkLabel(modifyProperty);
            setMethodIL.Emit(OpCodes.Ldarg_0);
            setMethodIL.Emit(OpCodes.Ldarg_1);
            setMethodIL.Emit(OpCodes.Stfld, fieldBuilder);
            setMethodIL.Emit(OpCodes.Nop);
            setMethodIL.MarkLabel(exitSet);
            setMethodIL.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getMethod);
            propertyBuilder.SetSetMethod(setMethod);
        }
    }
}
