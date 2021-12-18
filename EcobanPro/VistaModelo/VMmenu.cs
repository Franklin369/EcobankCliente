﻿using EcobanPro.Datos;
using EcobanPro.Modelo;
using EcobanPro.Vistas;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
namespace EcobanPro.VistaModelo
{
    public class VMmenu : BaseViewModel
    {
        public int contadorLogin;
        public List<Mdetallecompra> listViewSource=new List<Mdetallecompra>();
        private  string Nombre;
        Ddetallecompra funcion = new Ddetallecompra();
        public VMmenu(INavigation navigation, Mclientes client)
        {
            Navigation = navigation;
            Verdetallescommand = new Command<Mclientes>(async (param) => await Verdetalles(param));
            SolicitudRecojocommand = new Command<Mclientes>(async (param) => await SolicitarRecojo(param));

            var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
            NavigationPage.SetHasNavigationBar(page, false);
            Client = client;
            LoadData();
            //GetCategoriesAsync();
        }

        public async Task LoadData()
        {
            var funcion = new Ddetallecompra();
            this.ListViewSource = await funcion.MostrarDcompra(Client.Idcliente);
        }
        //public async Task Mostrardetallecompra()
        //{
        //    var funcion = new Ddetallecompra();
        //    //var parametros = new Mdetallecompra();
        //    //parametros.Idcliente = Client.Idcliente;
        //    this.ListViewSource = await funcion.MostrarDcompra();
        //}
        public List<Mdetallecompra> ListViewSource
        {
            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
        #region Properties
        public Command Logincommand { get; }
        public Command Verdetallescommand { get; }
        public Command SolicitudRecojocommand { get; }

        private async Task Verdetalles(Mclientes client)
        {
            var parametros = new Mclientes();
            parametros.Idcliente = Client.Idcliente;
            //client.Idcliente = Client.Idcliente;
            await Navigation.PushAsync(new Detallereciclado(parametros));
        }
        private async Task SolicitarRecojo(Mclientes client)
        {
            var parametros = new Mclientes();
            parametros.Idcliente = Client.Idcliente;
            //client.Idcliente = Client.Idcliente;
            await PopupNavigation.Instance.PushAsync(new Solicitarrecojo(parametros));
            //await Navigation.PushAsync(new Detallereciclado(parametros));
        }
        public string Nombretxt
        {
            get { return this.Nombre; }
            set { SetValue(ref this.Nombre, value); }
        }
        #endregion
       
       
        public Mclientes Client { get; set; }
    }
}
