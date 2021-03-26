using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using Tarea1_API.Models;
using Tarea1_API.DataBases;
using System.Collections.Generic;

namespace Tarea1_API.Controllers
{
    /*La clase LoginController controla todo lo accesado con el prefijo "api/login" contiene varias respuestas a un http ,verifica el login ingresado para ver si esta
     * en los datos guardados , y revisa el registro nuevo para confirmar de que no habia sido ingresado antes.
     * 
     */
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        //Verifica si el usuario ingresado, username y password coinciden con alguno guradado en el archivo Usuarios.json , recibiendo un objeto tipo Usuarios
        [HttpPost]
        [Route("verificar")]
        public IHttpActionResult Verificar(LoginRequest login)
        {
            DataBases.JsonController.verificacion_login(login);
            return Ok(DataBases.JsonController.verificacion_login(login));
        }

        //Agrega un nuevo cliente , chef o admin a la base de datos , recibiendo un objeto tipo Usuarios
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