using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTapeApp.Services
{
    /// <summary>
    /// Proxy Class for accessing dependency injection
    /// </summary>
    static class Resolver
    {
        private static IContainer _context;
        public static void SetContext(IContainer context) => _context = context;

        /// <summary>
        /// Resolve the type from the dependency container
        /// </summary>
        /// <param name="type">the type to resolve</param>
        /// <returns>and object of the given type</returns>
        public static object Resolve(Type type) => _context.Resolve(type);


        /// <summary>
        /// Resolve the type from the dependency container with the given service key
        /// </summary>
        /// <param name="serviceKey">the service key of the type</param>
        /// <param name="type">the type to resolve</param>
        /// <returns>and object of the given type</returns>
        public static object ResolveKeyed(object serviceKey, Type type) => _context.ResolveKeyed(serviceKey, type);


        /// <summary>
        /// Resolve the type from the dependency container with the given service name
        /// </summary>
        /// <param name="serviceName">the name of the specific service</param>
        /// <param name="type">the type to resolve</param>
        /// <returns>and object of the given type</returns>
        public static object ResolveName(string serviceName, Type type) => _context.ResolveNamed(serviceName, type);

        /// <summary>
        /// Resolve the type from the dependency container
        /// </summary>
        /// <typeparam name="T">the type to resolve</typeparam>
        /// <returns>and object of the given type</returns>
        public static T Resolve<T>() => _context.Resolve<T>();

        /// <summary>
        /// Resolve the type from the dependency container with the given service key
        /// </summary>
        /// <typeparam name="T">the type to resolve</typeparam>
        /// <param name="serviceKey">the service key of the type</param>
        /// <returns>and object of the given type</returns>
        public static T ResolveKeyed<T>(object serviceKey) => _context.ResolveKeyed<T>(serviceKey);

        /// <summary>
        /// Resolve the type from the dependency container with the given service name
        /// </summary>
        /// <typeparam name="T">the type to resolve</typeparam>
        /// <param name="serviceName">the name of the specific service</param>
        /// <returns>and object of the given type</returns>
        public static T ResolveName<T>(string serviceName) => _context.ResolveNamed<T>(serviceName);
    }
}
