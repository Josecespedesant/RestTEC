using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestTEC_Movil_App
{
    public partial class MainPage : ContentPage
    {
    
        public MainPage()
        {
            InitializeComponent();
            
            loginButton.Clicked += LoginButton_Clicked;

            var register_tap = new TapGestureRecognizer();
            register_tap.Tapped += Register_tap_Tapped;
          
            registrarseLabel.GestureRecognizers.Add(register_tap);
        }

        private async void Register_tap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string correo = email.Text;
            string pass = password.Text;
            if (string.IsNullOrWhiteSpace(correo)||string.IsNullOrWhiteSpace(pass))
            {
                Device.BeginInvokeOnMainThread(() =>
               {
                   DisplayAlert("Error", "Alguno de los dos campos está vacío.", "OK");
               });    
            }
            
            


        }
    }
}
