using System.Reflection;
using Autofac;
using DNDCatalog.Core;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Infrastructure.Data;
using DNDCatalog.Infrastructure.Identity;
using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;

namespace DNDCatalog.Infrastructure;
public class DefaultInfrastructureModule : Module
{
    private readonly bool _isDevelopment = false;
    private readonly List<Assembly> _assemblies = new List<Assembly>();

    public DefaultInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
    {
        _isDevelopment = isDevelopment;
        var coreAssembly = Assembly.GetAssembly(typeof(DefaultCoreModule));
        var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
        if (coreAssembly != null)
        {
            _assemblies.Add(coreAssembly);
        }

        if (infrastructureAssembly != null)
        {
            _assemblies.Add(infrastructureAssembly);
        }

        if (callingAssembly != null)
        {
            _assemblies.Add(callingAssembly);
        }
    }

    protected override void Load(ContainerBuilder builder)
    {
        if (_isDevelopment)
        {
            RegisterDevelopmentOnlyDependencies(builder);
        }
        else
        {
            RegisterProductionOnlyDependencies(builder);
        }

        RegisterCommonDependencies(builder);
    }

    private void RegisterCommonDependencies(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
          .As(typeof(IRepository<>))
          .As(typeof(IReadRepository<>))
          .InstancePerLifetimeScope();

        builder.RegisterType(typeof(SpellRepository))
          .As(typeof(ISpellRepository))
          .InstancePerLifetimeScope();

        builder.RegisterType(typeof(ClassRepository))
          .As(typeof(IClassRepository))
          .InstancePerLifetimeScope();

        builder.RegisterType(typeof(SourceRepository))
          .As(typeof(ISourceRepository))
          .InstancePerLifetimeScope();

        builder
          .RegisterType<Mediator>()
          .As<IMediator>()
          .InstancePerLifetimeScope();

        builder
          .RegisterType<DomainEventDispatcher>()
          .As<IDomainEventDispatcher>()
          .InstancePerLifetimeScope();

        builder
          .RegisterType<IdentityTokenClaimService>()
          .As<ITokenClaimsService>()
          .InstancePerLifetimeScope();

        builder.Register<ServiceFactory>(context =>
        {
            var c = context.Resolve<IComponentContext>();

            return t => c.Resolve(t);
        });

        var mediatrOpenTypes = new[]
        {
      typeof(IRequestHandler<,>),
      typeof(IRequestExceptionHandler<,,>),
      typeof(IRequestExceptionAction<,>),
      typeof(INotificationHandler<>),
    };

        foreach (var mediatrOpenType in mediatrOpenTypes)
        {
            builder
              .RegisterAssemblyTypes(_assemblies.ToArray())
              .AsClosedTypesOf(mediatrOpenType)
              .AsImplementedInterfaces();
        }
    }

    private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any development only services here
        //builder.RegisterType<FakeEmailSender>().As<IEmailSender>()
        //  .InstancePerLifetimeScope();
    }

    private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any production only services here
        //builder.RegisterType<SmtpEmailSender>().As<IEmailSender>()
        //  .InstancePerLifetimeScope();
    }
}
