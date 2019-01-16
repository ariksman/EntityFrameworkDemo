using System;
using System.Collections.Generic;
using CommonServiceLocator;
using Unity;

namespace EntityFrameworkDemo.ViewModels
{
    public class UnityServiceLocator : IServiceLocator
    {
        private readonly IUnityContainer _unityContainer;
        public UnityServiceLocator(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }
        public object GetInstance(Type serviceType)
        {
            return _unityContainer.Resolve(serviceType);
        }
        public object GetInstance(Type serviceType, string key)
        {
            return _unityContainer.Resolve(serviceType, key);
        }
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _unityContainer.ResolveAll(serviceType);
        }
        public TService GetInstance<TService>()
        {
            return _unityContainer.Resolve<TService>();
        }
        public TService GetInstance<TService>(string key)
        {
            return _unityContainer.Resolve<TService>(key);
        }
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return _unityContainer.ResolveAll<TService>();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}