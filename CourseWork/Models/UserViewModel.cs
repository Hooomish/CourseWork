using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public IEnumerable<SecurityRoleViewModel> ActiveRoles { get; set; }
        public IEnumerable<SecurityRoleViewModel> DeleteRoles { get; set; }
        public IEnumerable<SecurityRoleViewModel> AddRoles { get; set; }
    }
}