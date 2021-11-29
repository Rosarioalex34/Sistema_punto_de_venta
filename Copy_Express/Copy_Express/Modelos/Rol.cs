using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
    class Rol
    {
        public int cod_rol { get; set; }
        public String nom_rol { get; set; }
        public Rol() { }

        public Rol(int cod_rol, string nom_rol)
        {
            this.cod_rol = cod_rol;
            this.nom_rol = nom_rol;
        }
    }
}
