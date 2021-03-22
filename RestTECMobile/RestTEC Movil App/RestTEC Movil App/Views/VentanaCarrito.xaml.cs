using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestTEC_Movil_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VentanaCarrito : ContentPage
    {

        List<ItemSeleccion> listaItems;
        public VentanaCarrito(List<ItemSeleccion> listaItems)
        {
            this.listaItems = listaItems;
            BindingContext = new ItemSeleccion();
            InitializeComponent();
            OnGetList();
        }

        protected void OnGetList()
        {
            myList.ItemsSource = listaItems;
        }

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

        private void OnSave(object sender, EventArgs e)
        {
        }

        private void OnCancel(object sender, EventArgs e)
        {

        }
    }
}