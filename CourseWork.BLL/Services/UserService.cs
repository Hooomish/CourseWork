using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.BLL.DTO;
using CourseWork.DAL.Entities;
using CourseWork.BLL.Infrastructure;
using CourseWork.BLL.Interfaces;
using CourseWork.DAL.Interfaces;
using AutoMapper;
using Microsoft.Xrm.Sdk;
using CourseWork.BLL.Converting;

namespace CourseWork.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddRole(Guid User, Guid Role)
        {
            unitOfWork.UserRolesRepository.AddRole(User, Role);
        }

        public void DeleteRole(Guid User, Guid Role)
        {
            unitOfWork.UserRolesRepository.DeleteRole(User, Role);
        }

        public UserDTO GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUsers(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            IEnumerable<UserDTO> entities = unitOfWork.UsersRepository.GetAll().Users().ToList();

            foreach (var user in entities)
            {
                user.ActiveRoles = unitOfWork.UserRolesRepository.GetUserRole(user.Id).Roles();
            }

           return entities;
        }

    }
}
