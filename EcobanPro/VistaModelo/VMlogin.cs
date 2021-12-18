using EcobanPro.Datos;
using EcobanPro.Modelo;
using GalaSoft.MvvmLight.Command;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using EcobanPro.Vistas;
using Xamarin.Essentials;
using Plugin.SharedTransitions;

namespace EcobanPro.VistaModelo
{
    public class VMlogin : BaseViewModel
    {

        private string identificacion;
        private int contadorLogin = 0;
        public object listViewSource;
        public bool visibleInicio = true;
        public bool visiblefinal = false;
        public bool sininternetV = false;

        Mclientes client = new Mclientes();
        public VMlogin(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            Logincommand = new Command<Mclientes>(async (param) => await ExecutarValidacion(param));
            
            VisibleFinal = false;
            Sininternetv = false;
            ValidarConexInternet();
        }
        private void ValidarConexInternet()
        {
            if(Connectivity.NetworkAccess!=NetworkAccess.Internet)
            {
                VisibleInicio = false;
                Sininternetv = true;
            }
            else
            {
                VisibleInicio = true;
                Sininternetv = false;
            }
        }
        public Command Logincommand { get; }
        #region Propertiers
        public string Identificaciontxt
        {
            get { return this.identificacion; }
            set { SetValue(ref this.identificacion, value); }
        }
        #endregion
        #region Commands

        #endregion
        #region Metodos
        async Task Validarlogin(Mclientes client)
        {
            VisibleInicio = false;
            VisibleFinal = true;
            var funcion = new Dclientes();
            var parametros = new Mclientes();
            var funcionesta = new Destaticos();
            var dtest = await funcionesta.Mostrarestaticos();
            parametros.Identificacion = Identificaciontxt;
            var dt = await funcion.ValidarCliente(parametros);
            contadorLogin = dt.Count;    
            if (contadorLogin > 0)
            {
                double meta = 0;
                foreach (var est in dtest)
                {
                    parametros.Metapuntos = "Meta: " + est.Puntosmeta;
                    meta = Convert.ToDouble(est.Puntosmeta);
                }
                foreach (var data in dt)
                {
                    double puntos = Convert.ToDouble(data.Puntos);
                    parametros.NombresApe =data.NombresApe;
                    parametros.Idcliente = data.Idcliente;
                    parametros.FotoFachada = data.FotoFachada;
                    parametros.Totalcobrado = data.Totalcobrado;
                    parametros.Totalporcobrar = data.Totalporcobrar;
                    parametros.Puntos = (puntos / meta).ToString();
                    parametros.Kgacumulados = "Kg reciclados: [ " + data.Kgacumulados + " ]";
                    parametros.Puntosacum = "Puntos acumulados: " + puntos.ToString();
                }
                Application.Current.MainPage =new SharedTransitionNavigationPage(new Vistas.Menu(parametros));
            }
            else
            {
                VisibleInicio = true;
                VisibleFinal = false;
                await Application.Current.MainPage.DisplayAlert("Datos incorrectos", "No se encontro registros", "OK");
            }
        }
        public object ListViewSource
        {
            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
        public bool VisibleInicio
        {
            get { return this.visibleInicio; }
            set
            {
                SetValue(ref this.visibleInicio, value);
            }
        }
        public bool VisibleFinal
        {
            get { return this.visiblefinal; }
            set
            {
                SetValue(ref this.visiblefinal, value);
            }
        }
        public bool Sininternetv
        {
            get { return this.sininternetV; }
            set
            {
                SetValue(ref this.sininternetV, value);
            }
        }
        private async Task ExecutarValidacion(Mclientes client)
        {
            await Validarlogin(client);

        }

        #endregion
    }
}
