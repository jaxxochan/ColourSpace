using CS.Core.DI;
using System;

namespace CS.Core
{
    public class CsCore : IDisposable
    {
        private CSAppDIContainer _diContainer;

        public CsCore Init()
        {
            if (_diContainer == null)
            {
                _diContainer = new CSAppDIContainer();
                _diContainer.Build();
            }
            return this;
        }

        public T ResolveAppService<T>() where T : class
        {
            if (_diContainer == null)
            {
                throw new InvalidOperationException("Init was not called before using the Core Module.");
            }
            return _diContainer.Resolve<T>();
        }

        public void Dispose()
        {
            _diContainer?.Dispose();
        }
    }    
}
