using CourseWork.BLL.Interfaces;
using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CourseWork.Controllers
{
    [RoutePrefix("api/User")]
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }


        [Route("")]
        public IHttpActionResult Get()
        {
            var users = service.GetUsers();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [Route("{guid:Guid}")]
        public IHttpActionResult Put(Guid guid, [FromBody]UserViewModel userViewModel)
        {
            //Guid Id = new Guid(id);

            foreach (var item in userViewModel.AddRoles)
            {
                service.AddRole(guid, item.Id);
            }
            foreach (var item in userViewModel.DeleteRoles)
            {
                service.DeleteRole(guid, item.Id);
            }

            return Ok();
        }
        
    }
}