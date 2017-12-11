using System.Collections.Generic;

namespace CourseWork.BLL.DTO
{
    class AddedOrDeletedRoles
    {
        public IEnumerable<SecurityRoleDTO> AddedRoles { get; set; }
        public IEnumerable<UserDTO> DeletedRole { get; set; }
    }
}
