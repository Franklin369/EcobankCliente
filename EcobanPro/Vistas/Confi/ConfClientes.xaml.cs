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
    public partial class ConfClientes : ContentPage
    {
        public ConfClientes()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
          await  InsertarCliente();
        }
        async Task InsertarCliente()
        {
            var funcion = new VMclientes();
            var parametros = new Mclientes();
            parametros.FotoFachada = "-";
            parametros.Geo = "-";
            parametros.IdDepa = "Modelo";
            parametros.IdDis = "-";
            parametros.IdPais = "-";
            parametros.IdPro = "-";
            parametros.IdZona = "-";
            parametros.Identificacion = txtIdentificacion.Text;
            parametros.NombresApe = txtNombresApell.Text;
            await funcion.Insertarclientes(parametros);

        }
    }
}