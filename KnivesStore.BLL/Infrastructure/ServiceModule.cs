using KnivesStore.DAL.DataAccessors.DB.UnitOfWork;
using Ninject.Modules;

namespace KnivesStore.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<KnivesDbUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
