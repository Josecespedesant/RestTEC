using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestTEC_Movil_App
{
   /*
    *Clase VentanaCarrito
    *Clase encargada de la vista del carrito de compras.
    */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VentanaCarrito : ContentPage
    {
        
        List<ItemSeleccion> listaItems; //Lista de objetos de compras
        private static readonly HttpClient client = new HttpClient(); //Cliente para la conexión
        /*
         * Constructor que recibe la lista de los objetos seleccionados.
         */
        public VentanaCarrito(List<ItemSeleccion> listaItems)
        {
            this.listaItems = listaItems;
            BindingContext = new ItemSeleccion();
            InitializeComponent();
            OnGetList();
        }
        /*
         * Actualiza la lista que se observa en pantalla.
         */
        protected void OnGetList()
        {
            myList.ItemsSource = listaItems;
        }
        /*
         * Cambiar la cantidad de un objeto en el carrito.
         */
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Label tapped
            Label lbl = (Label)sender;

            //Precio
            var item = (TapGestureRecognizer)lbl.GestureRecognizers[0];
            var id = item.CommandParameter;
            int cantidad = Convert.ToInt32(id);

            string newquantity = await DisplayPromptAsync("Agregar al carrito.", "Ingrese la cantidad de items que desee.", initialValue: cantidad.ToString(), maxLength: 3, keyboard: Keyboard.Numeric);

            if (newquantity != null)
            {
                int nuevaCantidad = Int32.Parse(newquantity);

                if (nuevaCantidad == 0)
                {
                    for (int j = 0; j < listaItems.Count; j++)
                    {
                        if (listaItems.ElementAt(j).Data.Nombre == lbl.Text)
                        {
                            listaItems.RemoveAt(j);
                            myList.ItemsSource = listaItems;
                            return;
                        }
                    }
                }

                for (int j = 0; j < listaItems.Count; j++)
                {
                    if (listaItems.ElementAt(j).Data.Nombre == lbl.Text)
                    {
                        listaItems.ElementAt(j).Quantity = nuevaCantidad;
                        myList.ItemsSource = listaItems;
                        return;
                    }
                }
            }
           

        }
        /*
         * Realiza el pedido.
         */
        private async void OnSave(object sender, EventArgs e)
        {
            Random random = new Random();
            int numero = random.Next(1000);
            string stNum = numero.ToString();
            string cliente = "Pablosky";

            var pedidoDict = new Dictionary<string, string>();

            for(int i=0; i<listaItems.Count; i++)
            {
                pedidoDict.Add(listaItems.ElementAt(i).Data.Nombre,listaItems.ElementAt(i).Quantity.ToString());
            }
            string horaInicio = "2000-04-29T00:00:00";
            string horaFinal = "2000-04-29T00:00:00";
            string estado = "Pendiente";
            string chef = "";
            int feedback = 6;

            string dictstring = "{";

            foreach(KeyValuePair<string, string> keyValues in pedidoDict)
            {
                dictstring += keyValues.Key + " : " + keyValues.Value + ", ";
            }
            dictstring = dictstring.TrimEnd(',', ' ') + "}";
            Console.WriteLine(dictstring);

            var values = new Dictionary<string, string>
            {
                { "Código" , stNum},
                { "Cliente", cliente },
                { "Pedido" , dictstring},
                { "Hora_inicio", horaInicio},
                { "Hora_final", horaFinal},
                { "Estado", estado},
                { "chef_asignado", chef},
                { "Feedback", feedback.ToString()}
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://192.168.0.14/Tarea1_API/api/pedidos/agregar", content);
            var responseString = await response.Content.ReadAsStringAsync();

        }

        private void OnCancel(object sender, EventArgs e)
        {

        }
    }
}