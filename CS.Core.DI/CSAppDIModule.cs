using AuthApp.Repository;
using Autofac;
using System.IO;
using System.Linq;
using System.Reflection;
using Module = Autofac.Module;

namespace CS.Core.DI
{
    public class CSAppDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterTypes(builder);
            base.Load(builder);
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            string binFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Remove(0, 6);

            Assembly appServices = Directory.GetFiles(binFolderPath, "CS.Core.AppServices.dll")
                .Select(Assembly.LoadFrom)
                .Single();

            Assembly dataAccess = Directory.GetFiles(binFolderPath, "CS.Core.DataAccess.dll")
                .Select(Assembly.LoadFrom)
                .Single();

            //var appServiceTypes = appServices.GetTypes();
            builder.RegisterType<RepositoryProvider>().AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(appServices).AsSelf().AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(dataAccess).AsSelf().AsImplementedInterfaces().SingleInstance();
        }
    }
}
