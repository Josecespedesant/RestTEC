using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestTEC_Movil_App
{
    /*
    *Clase VentanaPrincipal
    *Clase encargada de la vista de la ventana principal.
    */
    public partial class VentanaPrincipal : ContentPage
    {
        /*
         * Constructor de la ventana principal.
         */
        public VentanaPrincipal()
        {
            InitializeComponent();
            
            loginButton.Clicked += LoginButton_Clicked;

            var register_tap = new TapGestureRecognizer();
            register_tap.Tapped += Register_tap_Tapped;
          
            registrarseLabel.GestureRecognizers.Add(register_tap);
        }
        /*
         * Cambia a la ventana de registro.
         */
        private async void Register_tap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VentanaRegistro());
        }
        /*
         * Intenta hacer un login.
         */
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string correo = email.Text;
            string pass = password.Text;
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(pass))
            {
                Device.BeginInvokeOnMainThread(() =>
               {
                   DisplayAlert("Error", "Alguno de los dos campos está vacío.", "OK");
               });
            }

            if (correo == "admin" && pass == "coco")
            {
                HttpClient client = new HttpClient();
                var values = new Dictionary<string, string>
                {
                    { "Username" , correo},
                    { "Password" , pass}
                };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://192.168.0.14/Tarea1_API/api/login/verificar", content);
                var contents = await response.Content.ReadAsStringAsync();
                Console.WriteLine(contents);
                if(contents == "\"admin\"")
                {
                    Console.WriteLine("Si entró");
                    await Navigation.PushAsync(new VentanaMenu());
                }
            }
            
            


        }
    }
}
