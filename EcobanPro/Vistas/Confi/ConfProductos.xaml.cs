using EcobanPro.Modelo;
using EcobanPro.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcobanPro.Vistas.Confi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfProductos : ContentPage
    {
        public ConfProductos()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            await  InsertarProducto();
        }
        async Task InsertarProducto()
        {
            var funcion = new VMproductos();
            var parametros = new Mproductos();
            parametros.Descripcion = txtDescripcion.Text ;
            parametros.Precioventa = txtPrecioventa.Text ;
            parametros.Preciocompra = txtPreciocompra.Text ;
           
            await funcion.Insertarproductos(parametros);

        }
    }
}