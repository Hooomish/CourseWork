using System.Collections.Generic;
using CourseWork.Helpers.Constants;
using CourseWork.BLL.DTO;
using Microsoft.Xrm.Sdk;

namespace CourseWork.BLL.Converting
{
    public static class DataConverting
    {
        public static SecurityRoleDTO Role(this Entity role)
        {
            SecurityRoleDTO roleDTO = new SecurityRoleDTO();

            roleDTO.Id = role.Id;
            roleDTO.Name = role.GetAttributeValue<string>(Constants.Name);

            return roleDTO;
        }

        public static UserDTO User(this Entity user)
        {
            UserDTO userDTO = new UserDTO();

            userDTO.Id = user.Id;
            userDTO.Fullname = user.GetAttributeValue<string>(Constants.Fullname);
            userDTO.Domainname = user.GetAttributeValue<string>(Constants.DomainName);

            return userDTO;
        }

        public static IEnumerable<UserDTO> Users(this IEnumerable<Entity> users)
        {            
            List<UserDTO> listOfUsers = new List<UserDTO>();

            foreach (var user in users)
            {
                listOfUsers.Add(user.User());
            }

            return listOfUsers;
        }
        public static IEnumerable<SecurityRoleDTO> Roles(this IEnumerable<Entity> roles)
        {
            List<SecurityRoleDTO> listOfRoles = new List<SecurityRoleDTO>();

            foreach (var role in roles)
            {
                listOfRoles.Add(role.Role());
            }

            return listOfRoles;
        }

    }
}
