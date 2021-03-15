using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestTEC_Movil_App
{
   
    public partial class ItemsDisplay : ContentPage
    {
        public int Count = 0;
        public short Counter = 0;
        public int SlidePosition = 0;
        int heightRowsList = 90;
        private const string Url = "http://rallycoding.herokuapp.com/api/music_albums";
        private HttpClient _client = new HttpClient();

        public ItemsDisplay()
        {
            InitializeComponent();
            BindingContext = new Items();
            OnGetList();
        }


        protected void OnGetList()
        {
            string jsonstring = @"[{'Nombre': 'Espagueti', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '600'}, 
                                   {'Nombre': 'Pizza', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '650'},
                                    {'Nombre': 'Canelones', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '800'},
                                    {'Nombre': 'Risotto', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '900'},
{'Nombre': 'Espagueti', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '600'}, 
                                   {'Nombre': 'Pizza', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '650'},
                                    {'Nombre': 'Canelones', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '800'},
                                    {'Nombre': 'Risotto', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '900'},
{'Nombre': 'Espagueti', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '600'}, 
                                   {'Nombre': 'Pizza', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '650'},
                                    {'Nombre': 'Canelones', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '800'},
                                    {'Nombre': 'Risotto', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '900'},
{'Nombre': 'Espagueti', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '600'}, 
                                   {'Nombre': 'Pizza', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '650'},
                                    {'Nombre': 'Canelones', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '800'},
                                    {'Nombre': 'Risotto', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '900'},
{'Nombre': 'Espagueti', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '600'}, 
                                   {'Nombre': 'Pizza', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '650'},
                                    {'Nombre': 'Canelones', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '800'},
                                    {'Nombre': 'Risotto', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '900'},
{'Nombre': 'Espagueti', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '600'}, 
                                   {'Nombre': 'Pizza', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '650'},
                                    {'Nombre': 'Canelones', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '800'},
                                    {'Nombre': 'Risotto', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '900'},
{'Nombre': 'Espagueti', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '600'}, 
                                   {'Nombre': 'Pizza', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '650'},
                                    {'Nombre': 'Canelones', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '800'},
                                    {'Nombre': 'Risotto', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '900'},
{'Nombre': 'Espagueti', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '600'}, 
                                   {'Nombre': 'Pizza', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '650'},
                                    {'Nombre': 'Canelones', 'Tipo': 'Italiana', 'Precio': '6000', 'Calorias': '800'},
                                    {'Nombre': 'Risotto', 'Tipo': 'Italiana', 'Precio': '10000', 'Calorias': '900'}
                                    ]";
            var tr = JsonConvert.DeserializeObject<List<Items>>(jsonstring);
            myList.ItemsSource = tr;
        }

        private void OnSave(object sender, EventArgs e)
        {

        }

        private void OnCancel(object sender, EventArgs e)
        {

        }
    }

    
}