using System.Web.Http;
using Tarea1_API.Models;
using Tarea1_API.DataBases;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tarea1_API.Controllers
{
    /*La clase PedidosController controla todo lo accesado con el prefijo "api/pedidos" contiene varias respuestas a un http ,devuelve una lista con los pedidos,
     * agrega, elimina y asigna un pedido en la base de datos 
     * 
     */
    [AllowAnonymous]
    [RoutePrefix("api/pedidos")]
    public class PedidosController : ApiController
    {
        //Devuleve una lista con los pedidos actuales
        [HttpGet]
        [Route("listapedidos")]
        public IHttpActionResult lista() {
            
            
            return Ok(DataBases.JsonController.DeserializeJsonFilePedidos(DataBases.JsonController.GetPedidosFromJson()));
        }

        //Agrega un pedido a la lista principal de pedidos , recibe un objeto de tipo Pedidos 
        [HttpPost]
        [Route("agregar")]
        public IHttpActionResult Agregar(Pedidos pedido)
        {
            List<Pedidos> pedidos_base = DataBases.JsonController.DeserializeJsonFilePedidos(DataBases.JsonController.GetPedidosFromJson());


            int i = 0;
            while (i < pedidos_base.Count)
            {
                if (pedido.Codigo == pedidos_base[i].Codigo)
                {
                    return Ok("Codigo del pedido ya ha sido usado");
                }
                i++;
            }
            pedidos_base.Add(pedido);
            DataBases.JsonController.SerializeJsonFilePedidos(pedidos_base);
            return Ok("Pedido Agregado");
        }

        //Elimina un pedido de la base de datos , recibe un objeto de tipo Pedidos 
        [HttpPost]
        [Route("eliminar")]
        public IHttpActionResult Borrar(Pedidos pedido)
        {
            List<Pedidos> pedidos_base = DataBases.JsonController.DeserializeJsonFilePedidos(DataBases.JsonController.GetPedidosFromJson());



            int i = 0;
            while (i < pedidos_base.Count)
            {
                if (pedido.Codigo == pedidos_base[i].Codigo)
                {
                    pedidos_base.RemoveAt(i);
                    DataBases.JsonController.SerializeJsonFilePedidos(pedidos_base);
                    return Ok("Pedido fue eliminado");
                }
                i++;
            }

            return Ok("Codigo de pedido no encontrado");
        }

        //Asigna un pedido existente a un chef , recibe un objeto de tipo Pedidos 
        [HttpPost]
        [Route("asignar")]
        public IHttpActionResult Asignar(Pedidos pedido)
        {
            List<Pedidos> pedidos_base = DataBases.JsonController.DeserializeJsonFilePedidos(DataBases.JsonController.GetPedidosFromJson());
            int i = 0;
            while (i < pedidos_base.Count)
            {
                if (pedido.Codigo == pedidos_base[i].Codigo)
                {
                    pedidos_base[i].chef_asignado = pedido.chef_asignado;
                    DataBases.JsonController.SerializeJsonFilePedidos(pedidos_base);
                    return Ok("Pedido fue asignado");
                }
                i++;
            }

            return Ok("Codigo de pedido no encontrado");
        }

        //Enviar pedidos asignados al chef 
        [HttpPost]
        [Route("asignado")]
        public IHttpActionResult Asignado(LoginRequest chef)
        {
            List<Pedidos> pedidos_base = DataBases.JsonController.DeserializeJsonFilePedidos(DataBases.JsonController.GetPedidosFromJson());
            List<Pedidos> pedidos_base2 = new List<Pedidos> { };
            int i = 0;
            while (i < pedidos_base.Count)
            {
                if (chef.Username == pedidos_base[i].chef_asignado)
                {
                    pedidos_base2.Add(pedidos_base[i]);

                }
                i++;
            }

            return Ok(pedidos_base2);
        }
    }
}
