using EcobanPro.Datos;
using EcobanPro.Modelo;
using EcobanPro.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace EcobanPro.Vistas.Compras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagregarcompra : ContentPage
    {
        public Pagregarcompra(Mproductos product)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new VMdetallecompra(Navigation, product);

        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        async Task InsertarDetalleventa()
        {
            var funcion = new Ddetallecompra();
            var parametros = new Mdetallecompra();

           
        }
    }
}