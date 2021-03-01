using Autofac;
using System;

namespace CS.Core.DI
{
    public class CSAppDIContainer : IDisposable
    {
        private readonly ContainerBuilder builder;
        private IContainer diContainer;

        public CSAppDIContainer()
        {
            builder = new ContainerBuilder();
            builder.RegisterModule<CSAppDIModule>();
        }

        public void Build()
        {
            diContainer = builder.Build();
        }

        public T Resolve<T>() where T : class
        {
            //Each call to ResolveAppService should return an instance of app service isolated from all other app services.
            //This is why we have lifetime scope per resolve.
            using (var scope = diContainer.BeginLifetimeScope())
            {
                return scope.Resolve<T>();
            }
        }

        public void Dispose()
        {
            diContainer?.Dispose();
        }
    }
}
