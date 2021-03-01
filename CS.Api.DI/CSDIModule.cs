using Autofac;
using CS.Api.Services.DI;
using CS.Core;
using System;

namespace CS.Api.DI
{
    public class CSDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Action<Type[]> noop = _ => { };
            var referencedAssemblies = new[] {
                //DataAccess
                typeof(Core.DataAccess.Demo.DemoQuery),
                typeof(Core.AppServices.Demo.DemoAppService)
            };
            noop(referencedAssemblies);

            builder.RegisterModule<ApiServiceDIModule>();

            var csModule = new CsCore().Init();
            builder.RegisterCSCoreInterfaces(csModule);
        }
    }
}
