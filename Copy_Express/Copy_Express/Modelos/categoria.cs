using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
    class categoria
    {
        private int cod_cat;
        private String des_cat;
        public categoria() { }

        public categoria(int cod_cat, string des_cat)
        {
            this.Cod_cat = cod_cat;
            this.Des_cat = des_cat;
        }

        public int Cod_cat
        {
            get
            {
                return cod_cat;
            }

            set
            {
                cod_cat = value;
            }
        }

        public string Des_cat
        {
            get
            {
                return des_cat;
            }

            set
            {
                des_cat = value;
            }
        }
    }
}
