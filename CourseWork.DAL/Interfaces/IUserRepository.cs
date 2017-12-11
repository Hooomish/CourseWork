using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DAL.Interfaces
{
    public interface IUserRepository: IRepository<Entity>
    {
        IEnumerable<Entity> GetUserRole(Guid guid);
        void AddRole(Guid User, Guid Role);
        void DeleteRole(Guid User, Guid Role);
    }
}
