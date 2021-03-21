using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tarea1_API.Models;

namespace Tarea1_API.Controllers
{
    /// <summary>
    /// admin controller class for testing security token with role admin
    /// </summary>
    /// 

    [AllowAnonymous]
    //[Authorize(Roles = "Administrator")]
    [RoutePrefix("api/plato")]
    public class PlatoController : ApiController
    {
        //Devuelve todos los platilos
        [HttpGet]
        [Route("menu")]
        public IHttpActionResult menu()
        {
            
            return Ok(DataBases.JsonController.DeserializeJsonFilePlatos(DataBases.JsonController.GetPlatosFromJson()));
        }

        [HttpPost]
        [Route("agregar")]
        public IHttpActionResult Agregar(Platos plato)
        {
            List<Platos> platos_base = DataBases.JsonController.DeserializeJsonFilePlatos(DataBases.JsonController.GetPlatosFromJson());


            int i = 0;
            while (i < platos_base.Count)
            {
                if (plato.Nombre == platos_base[i].Nombre )
                {
                    return Ok("Platillo ya ha sido Agregado");
                }
                i++;
            }
            
            platos_base.Add(plato);
            DataBases.JsonController.SerializeJsonFilePlatos(platos_base);
            return Ok("Platillo Agregado");
        }

        [HttpPost]
        [Route("eliminar")]
        public IHttpActionResult Borrar(Platos plato)
        {
            List<Platos> platos_base = DataBases.JsonController.DeserializeJsonFilePlatos(DataBases.JsonController.GetPlatosFromJson());


            int i = 0;
            while (i < platos_base.Count)
            {
                if (plato.Nombre == platos_base[i].Nombre)
                {
                    platos_base.RemoveAt(i);
                    DataBases.JsonController.SerializeJsonFilePlatos(platos_base);
                    return Ok("Platillo ya ha sido eliminado");
                }
                i++;
            }

            return Ok("Platillo no se ha encontrado");
        }


        [HttpPost]
        [Route("editar")]
        public IHttpActionResult Editar(Platos plato) 
        {
            List<Platos> platos_base = DataBases.JsonController.DeserializeJsonFilePlatos(DataBases.JsonController.GetPlatosFromJson());


            int i = 0;
            while (i < platos_base.Count)
            {
                if (plato.Nombre == platos_base[i].Nombre)
                {
                    if (plato.Descripcion != " ") {
                        platos_base[i].Descripcion = plato.Descripcion;
                    }
                    if (plato.Precio != 0)
                    {
                        platos_base[i].Precio = plato.Precio;
                    }
                    if (plato.Calorias != 0)
                    {
                        platos_base[i].Calorias = plato.Calorias;
                    }
                    if (plato.Tipo != " ")
                    {
                        platos_base[i].Tipo = plato.Tipo;
                    }
                    if (plato.Ventas != 0)
                    {
                        platos_base[i].Ventas = plato.Ventas;
                    }
                    DataBases.JsonController.SerializeJsonFilePlatos(platos_base);
                    return Ok("El Platillo ha sido actualizado");
                }
                i++;
            }
            return Ok("Platillo no se ha encontrado");
        }

        
    }
}
