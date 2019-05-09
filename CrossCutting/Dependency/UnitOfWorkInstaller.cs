using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domain.Interfaces;
using Infrastructure.Data.UnitOfWork;

namespace CrossCutting.Dependency
{
    public class UnitOfWorkInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>()
                                       .ImplementedBy<UnitOfWork>()
                                       .LifestyleTransient());
        }
    }
}
