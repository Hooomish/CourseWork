using CourseWork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.DAL.Entities;
using CourseWork.DAL.CRM;
using Microsoft.Xrm.Sdk;

namespace CourseWork.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CRMContext context;
        private static string connectionString = string.Empty;

        private UserRepository userRepository;
        public IRepository<Entity> UsersRepository { get { return userRepository; } }

        private SecurityRoleRepository roleRepository;
        public ISecurityRoleRepository SecurityRoleRepository { get { return roleRepository; } }

        private UserRepository usersRolesRepository;
        public IUserRepository UserRolesRepository { get { return usersRolesRepository; } }
        


        public UnitOfWork()
        {
            if(connectionString != string.Empty)
            {
                context = new CRMContext(connectionString);
                userRepository = new UserRepository(context);
                roleRepository = new SecurityRoleRepository(context);
                usersRolesRepository = new UserRepository(context);
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Connection(string connectionString)
        {
            UnitOfWork.connectionString = connectionString;
        }
    }
}
