using System;
using System.IO;
using System.Reflection;

namespace CareFusion.Mosaic.Core.Components
{
    /// <summary>
    /// Class which is able to dynamically load Mosaic component assemblies. 
    /// </summary>
    public static class ComponentLoader
    {
        /// <summary>
        /// Creates a new instance of the specified class in the specified assembly
        /// and returns it as the specified generic interface type.
        /// </summary>
        /// <param name='assemblyPath'>Relative path of the assembly which contains the requested class.</param>
        /// <param name='className'>Full name of the class to instantiate.</param>
        /// <typeparam name='T'>Type of interface to return.</typeparam>
        /// <returns>The newly created object instance if successful, <c>null</c> otherwise.</returns>
        public static T LoadInterface<T>(string assemblyPath, string className) where T : class
        {
            Type classType = GetTypeFromAssembly(assemblyPath, className);

            if (classType == null)
            {
                return null;
            }

            if (classType.GetInterface(typeof(T).FullName) == null)
            {
                return null;
            }

            object newInstance = Activator.CreateInstance(classType);

            if (newInstance == null)
            {
                return null;
            }

            return newInstance as T;
        }

        /// <summary>
        /// Loads the specified assembly and retrieves the specified class type from it.
        /// </summary>
        /// <param name="assemblyPath">Relative path of the assembly which contains the requested class.</param>
        /// <param name="className">Full name of the class type to return.</param>
        /// <returns>The requested type instance if successful, <c>null</c> otherwise.</returns>
        private static Type GetTypeFromAssembly(string assemblyPath, string className)
        {
            if (string.IsNullOrEmpty(className))
            {
                throw new ArgumentException("Invalid className specified.");
            }

            Assembly typeAssembly = Assembly.GetExecutingAssembly();

            if (string.IsNullOrEmpty(assemblyPath) == false)
            {
                string directoryPath = Path.GetDirectoryName(typeAssembly.Location);
                string assemblyFilePath = Path.Combine(directoryPath, assemblyPath);

                if (File.Exists(assemblyFilePath) == false)
                {
                    return null;
                }

                typeAssembly = Assembly.LoadFile(assemblyFilePath);
            }

            return typeAssembly.GetType(className);
        }
    }
}
