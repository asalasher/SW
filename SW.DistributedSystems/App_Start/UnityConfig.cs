using SW.DataAccess;
using SW.Domain.ServicesImplementations;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace SW.DistributedSystems
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IRepositoryRebels, RepositoryRebels>();
            container.RegisterType<IServicesRebels, ServicesRebels>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}