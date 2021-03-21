using System.Web.Http;
using Tarea1_API.Models;
using Tarea1_API.DataBases;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tarea1_API.Controllers
{
    /// <summary>
    /// customer controller class for testing security token 
    /// </summary>

    [AllowAnonymous]
    //[Authorize]
    [RoutePrefix("api/pedidos")]
    public class PedidosController : ApiController
    {
        [HttpGet]
        [Route("listapedidos")]
        public IHttpActionResult lista() {
            
            
            return Ok(DataBases.JsonController.DeserializeJsonFilePedidos(DataBases.JsonController.GetPedidosFromJson()));
        }

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
        //Enviar solo codigo y chef
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
    }
}
