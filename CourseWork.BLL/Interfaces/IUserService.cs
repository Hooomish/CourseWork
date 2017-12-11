using System;
using System.Collections.Generic;
using CourseWork.BLL.DTO;

namespace CourseWork.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();
        
        UserDTO GetUser(Guid id);

        void AddRole(Guid User, Guid Role);
        void DeleteRole(Guid User, Guid Role);
    }
}
