using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestTEC_Movil_App
{
    /*
    *Clase App
    *Encargada de iniciar la aplicación.
    */
    public partial class App : Application
    {
        //Constructor de la clase, inicia la ventana principal en un NavigationPage para facilitar el cambio de vistas.
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage( new VentanaPrincipal() );
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
