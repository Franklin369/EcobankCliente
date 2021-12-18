using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using EcobanPro.Modelo;
using EcobanPro.Conexiones;

namespace EcobanPro.Datos
{
   public class Dclientes
    {
        
        public async Task<List<Mclientes>> ValidarCliente(Mclientes parametrosPedir)
        {

            return (await Constantes.firebase
              .Child("Clientes")
              .OnceAsync<Mclientes>()).Where(a => a.Object.Identificacion == parametrosPedir.Identificacion).Select(item => new Mclientes
              {
                  Identificacion = item.Object.Identificacion,
                  NombresApe =item.Object.NombresApe ,
                  FotoFachada = item.Object.FotoFachada,
                  Idcliente=item.Key,
                  Totalcobrado =item.Object.Totalcobrado,
                  Totalporcobrar=item.Object.Totalporcobrar,
                  Puntos=item.Object.Puntos,
                  Kgacumulados=item.Object.Kgacumulados,

              }).ToList();
        }
    }
}
