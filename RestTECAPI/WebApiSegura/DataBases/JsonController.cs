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
        private static string path_usuario = @"C:\Users\PC\Documents\GitHub\RestTEC\RestTECAPI\WebApiSegura\DataBases\Usuarios.json";
        private static string path_plato = @"C:\Users\PC\Documents\GitHub\RestTEC\RestTECAPI\WebApiSegura\DataBases\Plato.json";
        private static string path_pedidos = @"C:\Users\PC\Documents\GitHub\RestTEC\RestTECAPI\WebApiSegura\DataBases\Pedidos.json";
        // (Login) Pasa el archivo a un string 
        public static string GetLoginFromJson()
        {
            
            string loginFromJson;
            using (var reader = new StreamReader(path_usuario))
            {
                loginFromJson = reader.ReadToEnd();

            }
            return loginFromJson;
        }
        //(Login) Guarda la informacion en los json
        public static void SerializeJsonFileLogin(List<Usuarios> loginS)
        {
            string loginJson = JsonConvert.SerializeObject(loginS.ToArray(), Formatting.Indented);
            File.WriteAllText(path_usuario, loginJson);
        }


        //(Login) Pasa de txt a json
        public static List<Usuarios> DeserializeJsonFileLogin(string logionFromJson)
        {
            List<Usuarios> product = JsonConvert.DeserializeObject<List<Usuarios>>(logionFromJson);
            //Console.WriteLine(product.Nombre);
            return product;
        }


        //(Platos) Pasa el archivo a un string 
        public static string GetPlatosFromJson()
        {

            string platosFromJson;
            using (var reader = new StreamReader(path_plato))
            {
                platosFromJson = reader.ReadToEnd();

            }
            return platosFromJson;
        }
        //(Platos) Guarda la informacion en los json
        public static void SerializeJsonFilePlatos(List<Platos> platos)
        {
            string platosJson = JsonConvert.SerializeObject(platos.ToArray(), Formatting.Indented);
            File.WriteAllText(path_plato, platosJson);
        }


        //(Platos) Pasa de txt a json
        public static List<Platos> DeserializeJsonFilePlatos(string platosFromJson)
        {
            List<Platos> product = JsonConvert.DeserializeObject<List<Platos>>(platosFromJson);
            //Console.WriteLine(product.Nombre);
            return product;
        }

        //(Pedidos) pasa un txt a un string 
        public static string GetPedidosFromJson()
        {

            string pedidosFromJson;
            using (var reader = new StreamReader(path_pedidos))
            {
                pedidosFromJson = reader.ReadToEnd();

            }
            return pedidosFromJson;
        }
        //(Pedidos) Guarda la informacion en los json
        public static void SerializeJsonFilePedidos(List<Pedidos> pedidos)
        {
            string pedidosJson = JsonConvert.SerializeObject(pedidos.ToArray(), Formatting.Indented);
            File.WriteAllText(path_pedidos, pedidosJson);
        }


        //(Pedidos) Pasa de txt a json
        public static List<Pedidos> DeserializeJsonFilePedidos(string pedidosFromJson)
        {
            List<Pedidos> product = JsonConvert.DeserializeObject<List<Pedidos>>(pedidosFromJson);
            //Console.WriteLine(product.Nombre);
            return product;
        }

        
        //Verifica el login
        public static string verificacion_login(LoginRequest login)
        {
            var data = GetLoginFromJson();
            List<Usuarios> user = DeserializeJsonFileLogin(data);
            int i = 0;
            while (i < user.Count) {
                if (login.Username == user[i].Username && login.Password == user[i].Password) {
                    return user[i].Acceso;
                }
                i++;
            }
            return "Datos incorrectos";
        }
        //Verifica la opcion de registro y guarda si es aceptada
        public static string verificacion_registro(Usuarios user) {
            var data = GetLoginFromJson();
            List<Usuarios> user_data = DeserializeJsonFileLogin(data);
            int i = 0;
            while (i < user_data.Count)
            {
                if (user.Username == user_data[i].Username || user.Cedula == user_data[i].Cedula)
                {
                    //error 
                    return "El nombre de usuario o el numero de cedula, ya estan ingresado";
                }
                i++;
            }
            //agrega al json
            user_data.Add(user);
            SerializeJsonFileLogin(user_data);
            return "Todo listo";
        }
    }


}