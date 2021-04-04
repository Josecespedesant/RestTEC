using Newtonsoft.Json.Linq;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /*
    *Clase VentanaRegistro
    *Clase encargada de la vista del registro.
    */
    public partial class VentanaRegistro : ContentPage
    {
        /*
         * Constructor de la ventana registro.
         */
        public VentanaRegistro()
        {
            InitializeComponent();
            botonconfirmar.Clicked += Botonconfirmar_Clicked;
        }
        /*
         * Confirma los datos del registro del cliente.
         */
        private async void Botonconfirmar_Clicked(object sender, EventArgs e)
        {
            string ced = cedula.Text;
            string name = nombre.Text;
            string ape1 = apelli1.Text;
            string ape2 = apelli2.Text;
            string prov = provincia.Text;
            string cant = canton.Text;
            string distr = distrito.Text;
            DateTime dt = startDatePicker.Date;
            string num = numero.Text;
            string corre = correo.Text;
            string pass = contraseña.Text;

            if(string.IsNullOrWhiteSpace(ced) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ape1) || string.IsNullOrWhiteSpace(ape2) ||
                string.IsNullOrWhiteSpace(prov) || string.IsNullOrWhiteSpace(cant) || string.IsNullOrWhiteSpace(distr) || string.IsNullOrWhiteSpace(num) ||
                string.IsNullOrWhiteSpace(corre) || string.IsNullOrWhiteSpace(pass))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Error", "Alguno de los campos está vacío.", "OK");
                });
            }

            if (string.IsNullOrWhiteSpace(corre) || !corre.Contains('@')){
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Error", "Correo no válido.", "OK");
                });
            }

            string direccion = "{" + "\"Provincia\"" + ": " + "\""+ prov + "\"" + "," + "\n" + "{" + "\"Provincia\"" + ": " + "\"" + prov + "\"" + "," + "\n" + "\"Canton\"" + ": " + "\"" + cant + "\"" + "," + "\n"
               + "{" + "\"Distrito\"" + ": " + "\"" + distr + "\"";

            string phone = "[" + num + "]";

            var values = new Dictionary<string, string>
            {
                { "Username" , corre},
                { "Password", pass },
                { "Nombre" , name},
                { "Apellido", ape1 },
                { "Cedula", ced},
                { "Direcciones", direccion},
                { "Fecha_nacimiento", dt.ToString()},
                { "Telefonos", phone},
                { "Acceso", "usuario"}
            };

            HttpClient client = new HttpClient();
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://192.168.0.14/Tarea1_API/api/login/Registrar", content);
            var contents = await response.Content.ReadAsStringAsync();
            if (contents == "\"Todo listo\"")
            {
                await Navigation.PushAsync(new VentanaPrincipal());
            }

        }
    }
}