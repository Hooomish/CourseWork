
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CourseWork.Helpers.Constants
{
    public class Constants
    {
        public static readonly string ConnectString = "AuthType = AD; Url=https://studdev.scnsoft.com/studdev; Domain=MAIN; Username=crm-test17@scnsoft.com; Password=Abcd1234";
        public static readonly string User = "systemuser";
        public static readonly string SecurityRole = "role";

        //Security Role
        public static readonly string Name = "name";
        public static readonly string IdRole = "roleid";

        //User
        public static readonly string IdUser = "systemuserid";
        public static readonly string Fullname = "fullname";
        public static readonly string DomainName = "domainname";

        //User Roles
        public static readonly string EntityName = "systemuserroles";
        public static readonly string IdUR = "systemuserid";
    }
}