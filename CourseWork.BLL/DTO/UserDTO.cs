using System;
using System.Collections.Generic;

namespace CourseWork.BLL.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Domainname { get; set; }
        public IEnumerable<SecurityRoleDTO> ActiveRoles { get; set; }        
    }
}
