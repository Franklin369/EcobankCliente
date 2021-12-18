using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using EcobanPro.Modelo;
using EcobanPro.Conexiones;
using EcobanPro.VistaModelo;

namespace EcobanPro.Datos
{
   public class Dsolicitudesrecojo
    {
        public async Task InsertarSolicitud(Msolicitudesrecojo parametros)
        {
            await Constantes.firebase
                    .Child("Solicitudesrecojo")
                    .PostAsync(new Msolicitudesrecojo()
                    {
                        Estado =parametros.Estado,
                        Fecha = parametros.Fecha,
                        Idcliente = parametros.Idcliente,
                        Idturno = parametros.Idturno
                    });
        }
    }
}
