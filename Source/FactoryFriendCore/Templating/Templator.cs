namespace FactoryFriendCore.Templating
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public sealed class Templator
    {
        private readonly List<Assembly> assemblies;

        public Templator(IEnumerable<Assembly> assemblies)
        {
            this.assemblies = assemblies.ToList();
        }

        public IList<Type> GatherTemplates()
        {
            var templateInstances = new List<Type>();
            assemblies.ForEach(assembly => templateInstances.AddRange(assembly.GetTypes().Where(TypeIsDerivedFromTemplateInterface)));
            return templateInstances;
        }

        private static bool TypeIsDerivedFromTemplateInterface(Type type)
        {
            return type.IsClass && typeof(IFactoryFriendTemplate).IsAssignableFrom(type);
        }

        public IList<MethodInfo> GatherMethodInfosForTemplates()
        {
            var types = this.GatherTemplates();
            var factoryMethodInfos = from type in types
                                     from methodInfo in type.GetMethods()
                                     where types.Contains(methodInfo.DeclaringType)
                                     select methodInfo;
            return factoryMethodInfos.ToList();
        }
    }
}
