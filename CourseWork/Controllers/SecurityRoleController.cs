using CourseWork.BLL.DTO;
using CourseWork.BLL.Interfaces;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CourseWork.Controllers
{
    [RoutePrefix("api/Role")]
    [EnableCors("*", "*", "*")]
    public class SecurityRoleController : ApiController
    {
        ISecurityRoleService service;

        public SecurityRoleController(ISecurityRoleService service)
        {
            this.service = service;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var roles = service.GetSecurityRoles();

            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        [Route("{guid:Guid}")]
        public IHttpActionResult Get(Guid id)
        {
            var roleDTO = new SecurityRoleDTO();
            roleDTO.Id = Guid.NewGuid();
            roleDTO.Name = "Role";

            return Ok(roleDTO);
        }
    }
}