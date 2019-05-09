using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Infrastructure.Data.Context;
using System.Web;

namespace CrossCutting.Dependency
{
    public class ContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<DatabaseContext>()
                                        .ImplementedBy<DatabaseContext>()
                                        .LifestyleTransient());
        }
    }
}
