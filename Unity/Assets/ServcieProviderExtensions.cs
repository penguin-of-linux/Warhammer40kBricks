using System;
using Extensibility;

namespace Assets
{
    public static class IServiceProviderExtensions
    {
        public static T GetService<T>(this IServiceProvider container)
        {
            if (typeof(T) == typeof(Engine))
                loh();
            return (T)container.GetService(typeof(T));
        }

        public static void loh()
        {
        }
    }
}