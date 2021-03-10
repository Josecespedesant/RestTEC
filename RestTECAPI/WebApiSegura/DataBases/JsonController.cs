using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Tarea1_API;
using Tarea1_API.Models;

namespace Tarea1_API.DataBases
{
    public class JsonController
    {
        private static string path = @"C:\Users\leona\Downloads\Tarea1\WebApiSegura\DataBases\Usuarios.json";
        public static string GetLoginFromJson()
        {
            string loginFromJson;
            using (var reader = new StreamReader(path))
            {
                loginFromJson = reader.ReadToEnd();

            }
            return loginFromJson;
        }

        public static List<Usuarios> DeserializeJsonFile(string logionFromJson)
        {
            List<Usuarios> product = JsonConvert.DeserializeObject<List<Usuarios>>(logionFromJson);
            //Console.WriteLine(product.Nombre);
            return product;
        }
    }
}