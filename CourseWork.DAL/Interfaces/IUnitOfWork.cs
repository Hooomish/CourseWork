using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.DAL.Entities;
using Microsoft.Xrm.Sdk;

namespace CourseWork.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Entity> UsersRepository { get; }
        ISecurityRoleRepository SecurityRoleRepository { get; }
        IUserRepository UserRolesRepository { get; }
        void Connection(string connectionString);
        
    }
}
