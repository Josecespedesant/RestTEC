using System;
using System.Collections.Generic;

namespace Tarea1_API.Models
{
    /// <summary>
    /// Clase Login, donde se maneja la informacion del cliente, usuarios y chefs 
    /// </summary>
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }


    public class Direccion
    {
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

    }
    public class Usuarios
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public List<Direccion> Direcciones { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public List<int> Telefonos { get; set; }
        public string Acceso { get; set; }


    }
    //Manejo de los platos 

    public class Platos
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Calorias { get; set; }
        public string Tipo { get; set; }
        public int Ventas { get; set; }

    }

    //Manejo de pedidos 
    public class Pedidos {
        public int  Codigo { get; set; }
        public string Cliente { get; set; }
        public List<Platos> Pedido { get; set; }
        public DateTime Hora_inicio { get; set; }
        public DateTime Hora_final { get; set; }
        public string Estado { get; set; }
        public string chef_asignado { get; set; }
        public int  Feedback { get; set; }
    }
}