using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assets.Container
{
    public class Container : IServiceProvider
    {
        public Container()
        {
            _mapToObject = new Dictionary<Type, object>();
            _mapToType = new Dictionary<Type, Type>();
            _isByObject = new Dictionary<Type, bool>();
            
        }

        public object GetService(Type serviceType)
        {
            if (!_isByObject.ContainsKey(serviceType))
                throw new ArgumentException(string.Format("Type {0} not registred", serviceType));

            if (_isByObject[serviceType])
            {
                if (!_mapToObject.ContainsKey(serviceType))
                    _mapToObject[serviceType] = Create(serviceType);

                return _mapToObject[serviceType];
            }

            return Create(serviceType);
        }

        public void Register<Tin, Tout>()
        {
            _mapToType[typeof(Tin)] = typeof(Tout);
            _isByObject[typeof(Tin)] = false;
        }

        public void RegisterSingleton<T>(T obj)
        {
            _mapToObject[typeof(T)] = obj;
            _isByObject[typeof(T)] = true;
        }

        public void RegisterSingleton<T>()
        {
            _isByObject[typeof(T)] = true;
        }

        public object Create(Type type)
        {
            var ctors = type.GetConstructors();

            if (ctors.Length != 1)
                throw new ArgumentException(string.Format("Type {0} has no only 1 contructor", type));

            var ctor = ctors[0];
            var parameters = new List<object>();

            foreach (var param in ctor.GetParameters())
                parameters.Add(GetService(param.ParameterType));

            return ctor.Invoke(parameters.ToArray());
        }

        public T Create<T>()
        {
            return (T) Create(typeof(T));
        }

        private readonly Dictionary<Type, object> _mapToObject;
        private readonly Dictionary<Type, Type> _mapToType;
        private readonly Dictionary<Type, bool> _isByObject;
    }
}