using Autofac;
using CS.Core;
using CS.Core.Authentication;
using CS.Core.Demo;
using CS.Core.Module;

namespace CS.Api.DI
{
    public static class CSCoreDIConfig
    {
        public static IContainer Container { get; set; }

        public static void RegisterCSCoreInterfaces(this ContainerBuilder builder, CsCore coreModule)
        {
            var core = coreModule;
            builder.Register(x => core.ResolveAppService<IDemoAppService>()).As<IDemoAppService>();
            builder.Register(x => core.ResolveAppService<IUserAppService>()).As<IUserAppService>();
            builder.Register(x => core.ResolveAppService<ITokenAppService>()).As<ITokenAppService>();
            builder.Register(x => core.ResolveAppService<IModuleAppService>()).As<IModuleAppService>();
        }
    }
}
