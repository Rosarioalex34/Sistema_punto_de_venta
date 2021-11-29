using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
   public  class Producto
    {
       
        private int cod_prod;
        private String nom_prod;
        private String marca;//cambiar
        private Decimal prec_com;///verificar
        private Decimal prec_vnta;
        private Decimal iva_prod;
        private int cant_prod;
        private String cod_categ;//cambiar

        public int Cod_prod
        {
            get
            {
                return cod_prod;
            }

            set
            {
                cod_prod = value;
            }
        }

        public string Nom_prod
        {
            get
            {
                return nom_prod;
            }

            set
            {
                nom_prod = value;
            }
        }

        public String Marca
        {
            get
            {
                return marca;
            }

            set
            {
                marca = value;
            }
        }

        public decimal Prec_com
        {
            get
            {
                return prec_com;
            }

            set
            {
                prec_com = value;
            }
        }

        public decimal Prec_vnta
        {
            get
            {
                return prec_vnta;
            }

            set
            {
                prec_vnta = value;
            }
        }

        public Decimal Iva_prod
        {
            get
            {
                return iva_prod;
            }

            set
            {
                iva_prod = value;
            }
        }

        public int Cant_prod
        {
            get
            {
                return cant_prod;
            }

            set
            {
                cant_prod = value;
            }
        }

        public String Cod_categ
        {
            get
            {
                return cod_categ;
            }

            set
            {
                cod_categ = value;
            }
        }

        public Producto() {
             
        }

        public Producto(int cod_prod, string nom_prod, String marca, decimal prec_com, decimal prec_vnta, Decimal iva_prod, int cant_prod, String cod_categ)
        {
            this.cod_prod = cod_prod;
            this.nom_prod = nom_prod;
            this.marca = marca;
            this.prec_com = prec_com;
            this.prec_vnta = prec_vnta;
            this.iva_prod = iva_prod;
            this.cant_prod = cant_prod;
            this.cod_categ = cod_categ;

        }
    }
}
    
