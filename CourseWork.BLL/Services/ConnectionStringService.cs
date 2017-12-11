using CourseWork.DAL.Interfaces;
using CourseWork.BLL.Interfaces;

namespace CourseWork.BLL.Services
{
    public class ConnectionStringService : IConnectionStringService
    {
        IUnitOfWork unitOfWork;

        public ConnectionStringService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public void Connection(string connectionString)
        {
            unitOfWork.Connection(connectionString);
        }
    }
}
