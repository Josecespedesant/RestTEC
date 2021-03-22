using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestTEC_Movil_App
{
   
    public partial class VentanaMenu : ContentPage
    {
        public int Count = 0;
        public short Counter = 0;
        public int SlidePosition = 0;
        List<ItemSeleccion> listaCompra;
        private HttpClient _client = new HttpClient();
        private const string Url = "http://192.168.0.14:49220/api/plato/menu";
        public VentanaMenu()
        {
            InitializeComponent();
            listaCompra = new List<ItemSeleccion>();
            BindingContext = new Items();
            OnGetList();
        }


        protected async void OnGetList()
        {
            /* if (CrossConnectivity.Current.IsConnected)
             {
                 try
                 {
                     var content = await _client.GetStringAsync(Url);
                     var tr = JsonConvert.DeserializeObject<List<Items>>(content);
                     ObservableCollection<Items> it = new ObservableCollection<Items>(tr);
                     myList.ItemsSource = it;

                 }catch(Exception ey)
                 {
                     Debug.WriteLine("" + ey);
                 }
             }*/
            string jsonstring = @"[{'Nombre': 'Espagueti', 'Descripcion': 'Comida rica', 'Precio': 10000, 'Calorias': 600, 'Tipo': 'Italiana'},
{'Nombre': 'Macarrones', 'Descripcion': 'Comida rica', 'Precio': 200000, 'Calorias': 600, 'Tipo': 'Italiana'},
{'Nombre': 'Tilapia', 'Descripcion': 'Comida rica', 'Precio': 30009, 'Calorias': 600, 'Tipo': 'Italiana'},
{'Nombre': 'Hamburguesa', 'Descripcion': 'Comida rica', 'Precio': 213412, 'Calorias': 600, 'Tipo': 'Italiana'},
{'Nombre': 'Zanahoria con culantro', 'Descripcion': 'Comida rica', 'Precio': 123344, 'Calorias': 600, 'Tipo': 'Italiana'}]";
            var tr = JsonConvert.DeserializeObject<List<Items>>(jsonstring);
            myList.ItemsSource = tr;
        }

        private void OnSave(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VentanaCarrito(listaCompra));
        }

        private void OnCancel(object sender, EventArgs e)
        {

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //ItemSeleccion objeto de ayuda
            ItemSeleccion itemSeleccion = new ItemSeleccion();
            //Cantidad de elementos
            string quantity = await DisplayPromptAsync("Agregar al carrito.", "Ingrese la cantidad que desee agregar al carrito", initialValue: "1", maxLength: 3, keyboard: Keyboard.Numeric);

            if (quantity != null)
            {
                int cantidad = Int32.Parse(quantity);
                //Label tapped
                Label lbl = (Label)sender;

                //Precio
                var item = (TapGestureRecognizer)lbl.GestureRecognizers[0];
                var id = item.CommandParameter;
                int precio = Convert.ToInt32(id);

                Items data = new Items();
                data.Nombre = lbl.Text;
                data.Precio = precio;

                itemSeleccion.Data = data;
                itemSeleccion.Quantity = cantidad;

                for(int i = 0; i<listaCompra.Count; i++)
                {
                    if (listaCompra.ElementAt(i).Data.Nombre == lbl.Text)
                    {
                        listaCompra.ElementAt(i).Quantity = listaCompra.ElementAt(i).Quantity + cantidad;
                        Console.WriteLine("AQUI1");
                        //Comida
                        Console.WriteLine(listaCompra.Last().Data.Nombre);
                        //Cantidad
                        Console.WriteLine(listaCompra.Last().Quantity) ;
                        //Precio
                        Console.WriteLine(listaCompra.Last().Data.Precio);
                        return;
                    }
                }
                //Se añade a la lista
                listaCompra.Add(itemSeleccion);
                Console.WriteLine("AQUI2");
                //Comida
                Console.WriteLine(listaCompra.Last().Data.Nombre);
                //Cantidad
                Console.WriteLine(listaCompra.Last().Quantity);
                //Precio
                Console.WriteLine(listaCompra.Last().Data.Precio);
            }

            
        }
    }

    
}