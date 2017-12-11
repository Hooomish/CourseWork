using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.DAL.Interfaces;
using CourseWork.DAL.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using CourseWork.Helpers.Constants;
using CourseWork.DAL.CRM;

namespace CourseWork.DAL.Repositories
{
    class UserRepository : ISecurityRoleRepository, IUserRepository
    {
        private CRMContext context;
        private bool disposed = false;

        public UserRepository(CRMContext context)
        {
            this.context = context;
        }

        public void Create(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entity entity)
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
                EntityName = Constants.User,
                ColumnSet = new ColumnSet(true)
            };

            var users = context.Service.RetrieveMultiple(queryConfig).Entities;            

            return users;
        }

        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        private User ConvertEntityToUser(Entity entity)
        {
            User user = new User();

            user.Name = entity.GetAttributeValue<string>(EntityFields.Name);
            user.Id = entity.GetAttributeValue<Guid>(EntityFields.Id);

            return user;
        }

        private IEnumerable<User> ConvertAllEntitiesToUsers(DataCollection<Entity> entities)
        {
            List<User> users = new List<User>();

            foreach (var entity in entities)
            {
                User user = ConvertEntityToUser(entity);

                users.Add(user);
            }

            return users;
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

        public void AddUserRole(Guid userGuid, Guid roleGuid)
        {
            //TODO
            throw new NotImplementedException();
        }

        public void DeleteUserRole(Guid userGuid, Guid roleGuid)
        {
            //TODO
            throw new NotImplementedException();
        }

        public IEnumerable<Entity> GetUserRole (Guid userId)
        {
            QueryExpression roleQuery = new QueryExpression()
            {
                EntityName = Constants.SecurityRole,
                ColumnSet = new ColumnSet(Constants.IdRole, Constants.Name)
            };

            LinkEntity roleLink = new LinkEntity()
            {
                LinkFromEntityName = Constants.SecurityRole,
                LinkFromAttributeName = Constants.IdRole,
                LinkToEntityName = Constants.EntityName,
                LinkToAttributeName = Constants.IdRole
            };

            LinkEntity userRoleLink = new LinkEntity()
            {
                LinkFromEntityName = Constants.EntityName,
                LinkFromAttributeName = Constants.IdUser,
                LinkToEntityName = Constants.User,
                LinkToAttributeName = Constants.IdUser
            };

            var conditionExpression = new ConditionExpression
            {
                AttributeName = Constants.IdUR,
                Operator = ConditionOperator.Equal
            };
            conditionExpression.Values.Add(userId);

            userRoleLink.LinkCriteria = new FilterExpression();
            userRoleLink.LinkCriteria.Conditions.Add(conditionExpression);

            roleLink.LinkEntities.Add(userRoleLink);
            roleQuery.LinkEntities.Add(roleLink);

            return context.Service.RetrieveMultiple(roleQuery).Entities;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void AddRole(Guid userId, Guid roleId)
        {
            context.Service.Associate(
                        Constants.User,
                        userId,
                        new Relationship("systemuserroles_association"),
                        new EntityReferenceCollection() { new EntityReference(Constants.SecurityRole, roleId) });
            
        }

        public void DeleteRole(Guid userId, Guid roleId)
        {
            context.Service.Disassociate(
                Constants.User,
                userId,
                new Relationship("systemuserroles_association"),
                new EntityReferenceCollection() { new EntityReference(Constants.SecurityRole, roleId) });
        }
    }
}
