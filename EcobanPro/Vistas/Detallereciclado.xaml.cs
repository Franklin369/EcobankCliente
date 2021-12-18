using EcobanPro.Modelo;
using EcobanPro.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcobanPro.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detallereciclado : ContentPage
    {
        public Detallereciclado(Mclientes client)
        {
            InitializeComponent();
            BindingContext = new VMdetallereciclado(Navigation,client);
        }
    }
}