using Autofac;
using CS.Api.Services.Authentication;
using CS.Api.Services.Demo;
using CS.Api.Services.Module;

namespace CS.Api.Services.DI
{
    public class CSApiDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DemoService>().AsImplementedInterfaces();
            builder.RegisterType<TokenService>().AsImplementedInterfaces();
            builder.RegisterType<UserService>().AsImplementedInterfaces();
            builder.RegisterType<ModuleService>().AsImplementedInterfaces();
        }
    }
}
