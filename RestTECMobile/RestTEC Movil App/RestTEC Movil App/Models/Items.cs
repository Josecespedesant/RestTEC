using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestTEC_Movil_App
{
    public class Items
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Calorias { get; set; }
        public string Tipo { get; set; }
    }
}
