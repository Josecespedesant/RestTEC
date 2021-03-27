using System;
using System.Collections.Generic;

namespace Tarea1_API.Models
{
    /*
     * En este archivo se obvservan varias clases, el manejo de archivos se realiza mediante estas clases y asi se maneja el json, cada clase contiene atributos
     * especificos sobre cada entidad
     */

    //La clase LoginRequest contiene un Username y password 
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    //La clase Direccion , tiene la estructura de provincia, canton y distrito
    public class Direccion
    {
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

    }
    //La clase Usuario, contiene gran cantidad de atributos los cuales son esenciales para la entidad usuarios
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
        public int Cant_Ordenes { get; set; }

    }
    
    
    //La clase Platos , contiene atributos de esa entidad y de esa manera se manejaran los pedidos y menu
    public class Platos
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Calorias { get; set; }
        public string Tipo { get; set; }
        public int Ventas { get; set; }
        public int Feedback { get; set; }
    }

    //La clase Pedidos , contiene atributos caracteristicos y contiene otro tipo de clases en su interior para manejar de mejor manera la informacion en el API
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