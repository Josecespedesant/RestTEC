using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Tarea1_API.Controllers
{
    /// <summary>
    /// admin controller class for testing security token with role admin
    /// </summary>
    /// 

    [AllowAnonymous]
    //[Authorize(Roles = "Administrator")]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {

        [HttpGet]
        [Route("ver")]
        public IHttpActionResult pain()
        {
            return Ok("Listo ver");
        }

        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            var adminFake = "admin-fake: " + id;
            return Ok(adminFake);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var adminList = new string[] { "admin-1", "admin-2", "admin-3" };
            return Ok(adminList);
        }
    }
}
