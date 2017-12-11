using System.Collections.Generic;
using CourseWork.BLL.DTO;

namespace CourseWork.BLL.Interfaces
{
    public interface ISecurityRoleService
    {
        IEnumerable<SecurityRoleDTO> GetSecurityRoles();
    }
}
