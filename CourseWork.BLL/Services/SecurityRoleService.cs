using System.Collections.Generic;
using CourseWork.BLL.DTO;
using CourseWork.BLL.Interfaces;
using CourseWork.DAL.Interfaces;
using CourseWork.BLL.Converting;

namespace CourseWork.BLL.Services
{
    public class SecurityRoleService : ISecurityRoleService
    {
        IUnitOfWork unitOfWork;

        public SecurityRoleService (IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<SecurityRoleDTO> GetSecurityRoles()
        {
            IEnumerable<SecurityRoleDTO> entities = unitOfWork.SecurityRoleRepository.GetAll().Roles();
            return entities;
        }
        
    }
}
