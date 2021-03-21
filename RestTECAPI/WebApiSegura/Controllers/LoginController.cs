using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using Tarea1_API.Models;
using Tarea1_API.DataBases;
using System.Collections.Generic;

namespace Tarea1_API.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        //Verifica si el usuario ingresado, username y password coinciden con alguno guradado en el archivo Usuarios.json
        [HttpPost]
        [Route("verificar")]
        public IHttpActionResult Verificar(LoginRequest login)
        {
            DataBases.JsonController.verificacion_login(login);
            return Ok(DataBases.JsonController.verificacion_login(login));
        }

        [HttpPost]
        [Route("Registrar")]
        public IHttpActionResult Registrar(Usuarios user)
        {
            if (user.Username != null && user.Password != null && user.Nombre != null && user.Apellido != null ) {
                if (user.Username != "" && user.Password != "" && user.Nombre != "" && user.Apellido != "")
                {
                    
                    return Ok(DataBases.JsonController.verificacion_registro(user));
                }
            }
            return Ok("Algun dato esta erroneo");
        }

        

    }

}