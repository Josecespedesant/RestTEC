using Newtonsoft.Json.Linq;
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
    public partial class VentanaRegistro : ContentPage
    {
        public VentanaRegistro()
        {
            InitializeComponent();
            botonconfirmar.Clicked += Botonconfirmar_Clicked;
        }

        private void Botonconfirmar_Clicked(object sender, EventArgs e)
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
            //Se genera un array de para crear el Json
            JArray array = new JArray();
            //Se crea cada uno de los elementos del array
            JValue jced = new JValue(ced);
            JValue jname = new JValue(name);
            JValue jape1 = new JValue(ape1);
            JValue jape2 = new JValue(ape2);
            JValue jprov = new JValue(prov);
            JValue jcant = new JValue(cant);
            JValue jdistr = new JValue(distr);
            JValue jdt = new JValue(dt);
            JValue jnum = new JValue(num);
            JValue jcorre = new JValue(corre);
            JValue jpass = new JValue(pass);

            array.Add(jced);
            array.Add(jname);
            array.Add(jape1);
            array.Add(jape2);
            array.Add(jprov);
            array.Add(jcant);
            array.Add(jdistr);
            array.Add(jdt);
            array.Add(jnum);
            array.Add(jcorre);
            array.Add(jpass);

            Console.Write(array.ToString());

        }
    }
}