using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
    class Detalle_compra
    {
        private int cod_compra;
        private int cant_comp;
        private int cod_prod;
        private decimal prec_compra;
        private decimal iva;
        private decimal descuento;
        private decimal total;

        public int Cod_compra
        {
            get
            {
                return cod_compra;
            }

            set
            {
                cod_compra = value;
            }
        }

        public int Cant_comp
        {
            get
            {
                return cant_comp;
            }

            set
            {
                cant_comp = value;
            }
        }

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

        public decimal Prec_compra
        {
            get
            {
                return prec_compra;
            }

            set
            {
                prec_compra = value;
            }
        }

        public decimal Iva
        {
            get
            {
                return iva;
            }

            set
            {
                iva = value;
            }
        }

        public decimal Descuento
        {
            get
            {
                return descuento;
            }

            set
            {
                descuento = value;
            }
        }

        public decimal Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
        public Detalle_compra() { }

        public Detalle_compra(int cod_compra, int cant_comp, int cod_prod, decimal prec_compra, decimal iva, decimal descuento, decimal total)
        {
            this.Cod_compra = cod_compra;
            this.Cant_comp = cant_comp;
            this.Cod_prod = cod_prod;
            this.Prec_compra = prec_compra;
            this.Iva = iva;
            this.Descuento = descuento;
            this.Total = total;
        }
    }
}
