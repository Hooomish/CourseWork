using Ninject.Modules;
using CourseWork.DAL.Interfaces;
using CourseWork.DAL.Repositories;

namespace CourseWork.BLL.Infrastructure
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
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
