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
   public  class Dturnosrecojos
    {
        public async Task<List<Mturnosrecojo>> Mostrarturnosrecojo()
        {

            return (await Constantes.firebase
              .Child("Turnosrecojo")
              .OnceAsync<Mturnosrecojo>()).Select(item => new Mturnosrecojo
              {
                  Idturno = item.Key,
                  Turno = item.Object.Turno
              }).ToList();

        }
    }
}
