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

        public static T Resolve<T>() => _context.Resolve<T>();
        public static object Resolve(Type type) => _context.Resolve(type);
    }
}
