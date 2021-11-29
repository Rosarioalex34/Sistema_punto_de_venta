using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
    class marca
    {
        private int cod_marca;
        private String descripcion;
        public marca() { }

        public marca(int cod_marca, string descripcion)
        {
            this.Cod_marca = cod_marca;
            this.Descripcion = descripcion;
        }

        public int Cod_marca
        {
            get
            {
                return cod_marca;
            }

            set
            {
                cod_marca = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
    }
}
