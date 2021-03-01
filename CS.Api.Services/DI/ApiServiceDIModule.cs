using Autofac;

namespace CS.Api.Services.DI
{
    public class ApiServiceDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CSApiDIModule>();
        }
    }
}
