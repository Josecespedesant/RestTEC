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
    /*
     *Clase VentanaMenu
     *Clase encargada de la vista del menú.
     */
    public partial class VentanaMenu : ContentPage
    {
        public int Count = 0;
        public short Counter = 0;
        public int SlidePosition = 0;
        List<ItemSeleccion> listaCompra;
        private HttpClient _client = new HttpClient();
        private const string Url = "http://192.168.0.14/Tarea1_API/api/plato/menu";
        /*
        *Clase VentanaMenu
        *Clase encargada de la vista del carrito de compras.
        */
        public VentanaMenu()
        {
            InitializeComponent();
            listaCompra = new List<ItemSeleccion>();
            BindingContext = new Items();
            OnGetList();
        }
        /*
         * Actualiza la lista que se despliega.
         */
        protected async void OnGetList()
        {
             if (CrossConnectivity.Current.IsConnected)
             {
                 try
                 {
                     var content = await _client.GetStringAsync(Url);
                     var tr = JsonConvert.DeserializeObject<List<Items>>(content);
                    Console.WriteLine(tr);
                     ObservableCollection<Items> it = new ObservableCollection<Items>(tr);
                    Console.WriteLine(it);
                    myList.ItemsSource = it;

                 }catch(Exception ey)
                 {
                     Debug.WriteLine("" + ey);
                 }
             }
        }
        /*
         * Guarda los items seleccionados del menú y los manda al carrito.
         */
        private void OnSave(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VentanaCarrito(listaCompra));
        }

        private void OnCancel(object sender, EventArgs e)
        {

        }
        /*
         * Agrega el item al carrito.
         */
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