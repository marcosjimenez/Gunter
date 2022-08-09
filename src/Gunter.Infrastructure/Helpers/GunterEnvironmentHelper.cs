using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Reflection;

namespace Gunter.Core
{
    public class GunterEnvironmentHelper
    {
        private static readonly Lazy<GunterEnvironmentHelper> lazy = new (() => new GunterEnvironmentHelper());
        public static GunterEnvironmentHelper Instance {get => lazy.Value;}

        private Type[] CoreTypes = new [] { 
            typeof(IGunterProcessor), 
            typeof(IGunterInfoItem), 
            typeof(IGunterInfoSource), 
            typeof(IGunterVisualizationHandler) 
        };

        public Dictionary<Type, List<Type>> KnowTypes { get; private set; } = new();

        private GunterEnvironmentHelper()
        {
            LoadKnowTypes();
        }

        public List<Type> GetAvailableInfoSources()
        {
            List<Type> retVal = new();
            var handlers = KnowTypes[typeof(IGunterInfoSource)];

            retVal.AddRange(handlers.ToList());

            return retVal;
        }


        public List<Type> GetAvailableVisualizationHandlers()
        {
            List<Type> retVal = new();
            var handlers = KnowTypes[typeof(IGunterVisualizationHandler)];

            retVal.AddRange(handlers.ToList());

            return retVal;
        }

        public static bool TrySetProperty<T>(T target, string propertyName, object value)
        {
            if (target is null)
                return false;

            var type = target?.GetType();
            var prop = type?.GetProperty("propertyName");
            try
            {
                prop.SetValue(target, value, null);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static string GetSystemTypeName(Type type)
            => $"{type}, {type.Namespace}";

        public T? CreateInstance<T>(string typeName, params object?[] args)
        {
            var type = GetAllTypes().Where(x => GetSystemTypeName(x) == typeName)
                .FirstOrDefault();

            if (type is null)
                throw new GunterSolutionException($"invalid SystemType ({typeName})");

            try
            {
                var instance = Activator.CreateInstance(type, args);
                return (T)instance;

            }
            catch (Exception ex)
            {
                throw new GunterSolutionException($"Cannot create instance of {type}", ex);
            }
        }

        public List<Type> GetAvailableTypesOf(string type)
            => GetAvailableTypesOf(Type.GetType(type));

        public List<Type> GetAvailableTypesOf(Type type)
         => KnowTypes[type] ?? new List<Type>();

        private void LoadKnowTypes()
        {
            KnowTypes.Clear();
            foreach (var item in CoreTypes)
                KnowTypes.Add(item, GetTypesOf(item));
        }

        private List<Type> GetTypesOf(Type type)
        {
            //var type = typeof(T);
            //var types = AppDomain.CurrentDomain.GetAssemblies()
            //     .SelectMany(s => s.GetTypes())
            //    .Where(p => !type.Equals(p) && type.IsAssignableFrom(p))
            //    .ToList();

            var types = GetTypesFromFileSystem(type);

            return types;
        }

        private List<Type> GetTypesFromFileSystem(Type type)
        {
            var basePath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            var files = Directory.GetFiles(basePath, "Gunter.*.dll");
            var retVal = new List<Type>();
            try
            {
                foreach(var file in files)
                {
                    var assembly = Assembly.LoadFrom(file);
                    var items = assembly.GetTypes()
                        .Where(p => !type.Equals(p) && type.IsAssignableFrom(p) && !retVal.Contains(p));
                    retVal.AddRange(items);
                }
            }
            catch { }

            return retVal;
        }

        private List<Type> GetAllTypes()
        {
            List<Type> retVal = new();
            foreach (var pair in KnowTypes)
                retVal.AddRange(pair.Value);

            return retVal;
        }

    }
}
