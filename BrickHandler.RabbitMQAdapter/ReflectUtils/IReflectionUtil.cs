using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BrickHandler.RabbitMQAdapter.ReflectUtils
{
    public class ReflectionUtil : IReflectionUtil
    {
        public IEnumerable<Assembly> GetAssemblies()
        {
            IEnumerable<Assembly?> assemblies = Assembly.GetEntryAssembly()
                ?.GetReferencedAssemblies()
                .Select(a => Assembly.Load(a))
                .Append(Assembly.GetEntryAssembly());

            return assemblies;
        }

        public IEnumerable<Type> GetTypes(IEnumerable<Assembly> assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetTypes());
            return types;
        }


    }

    public interface IReflectionUtil
    {
        IEnumerable<Assembly> GetAssemblies();
        IEnumerable<Type> GetTypes(IEnumerable<Assembly> assemblies);

    }
}
