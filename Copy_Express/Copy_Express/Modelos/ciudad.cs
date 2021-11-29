using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
  public  class ciudad
    {
        public int cod_ciu { get; set; }
        public String nom_ciu { get; set; }
        public ciudad() { }
        public ciudad(int cod_ciu, string nom_ciu)
        {
            this.cod_ciu = cod_ciu;
            this.nom_ciu = nom_ciu;
        }
    }
}
