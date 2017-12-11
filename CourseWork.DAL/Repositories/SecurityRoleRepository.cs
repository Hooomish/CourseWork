using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.DAL.Interfaces;
using CourseWork.DAL.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling;
using CourseWork.Helpers.Constants;
using CourseWork.DAL.CRM;
using CourseWork.Helpers;

namespace CourseWork.DAL.Repositories
{
    public class SecurityRoleRepository : ISecurityRoleRepository
    {
        private CRMContext context;
        private bool disposed = false;

        public SecurityRoleRepository(CRMContext context)
        {
            this.context = context;
        }

        public void Create(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Entity Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity> GetAll()
        {
            QueryExpression queryConfig = new QueryExpression()
            {
                EntityName = Constants.SecurityRole, 
                ColumnSet = new ColumnSet(true)
            };

            IEnumerable<Entity> securityRoles = context.Service.RetrieveMultiple(queryConfig).Entities;

            return securityRoles;
        }

        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        private SecurityRole ConvertEntityToSecurityRole(Entity entity)
        {
            SecurityRole securityRole = new SecurityRole();

            securityRole.Name =  entity.GetAttributeValue<string>(EntityFields.Name);
            securityRole.Id = entity.GetAttributeValue<Guid>(EntityFields.Id);

            return securityRole;
        }

        private IEnumerable<SecurityRole> ConvertAllEntitiesToSecurityRoles(DataCollection<Entity> entities)
        {
            List<SecurityRole> securityRoles = new List<SecurityRole>();

            foreach (var entity in entities)
            {
                SecurityRole securityRole = ConvertEntityToSecurityRole(entity);

                securityRoles.Add(securityRole);
            }

            return securityRoles;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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
        
    }
}
