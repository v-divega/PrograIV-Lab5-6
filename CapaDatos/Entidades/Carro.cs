using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entidades
{
   public class Carro
    {
        public int idCarro { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Pais { get; set; }
        public double Costo { get; set; }
    }
}
