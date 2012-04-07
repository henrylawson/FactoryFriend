namespace FactoryFriendCore.Templating
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public sealed class Templator
    {
        private readonly string binPath;

        public Templator(string currentDomainSearchPath, string executingAssemblyLocation)
        {
            this.binPath = DetermineBinPath(currentDomainSearchPath, executingAssemblyLocation);
        }

        private static string DetermineBinPath(string currentDomainSearchPath, string executingAssemblyLocation)
        {
            var possibleBinPath = currentDomainSearchPath;
            if (String.IsNullOrEmpty(possibleBinPath))
            {
                possibleBinPath = Path.GetDirectoryName(executingAssemblyLocation);
                if (String.IsNullOrEmpty(possibleBinPath))
                {
                    throw new InvalidOperationException("Assembly location folder is null or empty");
                }
            }
            return possibleBinPath;
        }

        private IEnumerable<string> FindAllAssemblyPaths()
        {
            var assemblyPaths = Directory.GetFiles(this.binPath, "*.dll");
            return assemblyPaths;
        }

        public IList<Type> GatherTemplates()
        {
            var templateInstances = new List<Type>();
            var assemblyPaths = this.FindAllAssemblyPaths();
            foreach (var assembly in assemblyPaths.Select(Assembly.LoadFrom))
            {
                templateInstances.AddRange(assembly.GetTypes().Where(t => t.IsClass && typeof(IFactoryFriendTemplate).IsAssignableFrom(t)));
            }
            return templateInstances;
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
