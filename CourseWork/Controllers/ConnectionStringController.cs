using System;
using System.Web.Http;
using System.Web.Http.Cors;
using CourseWork.Models;
using CourseWork.BLL.Interfaces;

namespace CourseWorkWEB.Controllers
{
    [RoutePrefix("api/ConnectionString")]
    [EnableCors("*", "*", "*")]
    public class ConnectionStringController : ApiController
    {
        IConnectionStringService service;

        public ConnectionStringController(IConnectionStringService service)
        {
            this.service = service;
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]ConnectionStringViewModel connectionString)
        {
            if (connectionString == null || connectionString.ConnectionString == String.Empty)
            {
                return NotFound();
            }            

            string connectString = connectionString.ConnectionString;
            service.Connection(connectString);

            return Ok();
            
        }

        //12345444
        

    }
}