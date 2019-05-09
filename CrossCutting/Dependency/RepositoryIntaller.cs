using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Infrastructure.Data.Repositories;

namespace CrossCutting.Dependency
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Types.FromAssembly(typeof(UsuarioRepository).Assembly)
                                    .InSameNamespaceAs<UsuarioRepository>()
                                    .WithService.DefaultInterfaces()
                                    .LifestyleTransient());
        }
    }
}
