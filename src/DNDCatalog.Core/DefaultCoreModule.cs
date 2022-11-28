using Autofac;
using DNDCatalog.Core.Interfaces;

namespace DNDCatalog.Core;
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    //builder.RegisterType<ToDoItemSearchService>()
    //    .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
