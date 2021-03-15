using System;
using System.Collections.Generic;
using System.Text;

namespace RestTEC_Movil_App.Models
{
    public class ItemSeleccion<T>
    {
        public T Data { get; set; }
        public bool Selected { get; set; }
    }
}
