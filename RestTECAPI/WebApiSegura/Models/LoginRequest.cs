using System;
using System.Collections.Generic;

namespace Tarea1_API.Models
{
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
        public string Fecha_nacimiento { get; set; }
        public List<int> Telefonos { get; set; }
        

    }
}