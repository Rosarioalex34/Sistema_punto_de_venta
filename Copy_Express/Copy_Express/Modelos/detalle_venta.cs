using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
    class detalle_venta
    {
        private String cod_vnta;
        private int cant;
        private int cod_prod;
        private decimal prec_unit;
        private decimal iva;
        private decimal descuento;
        private decimal total;

        public string Cod_vnta
        {
            get
            {
                return cod_vnta;
            }

            set
            {
                cod_vnta = value;
            }
        }

        public int Cant
        {
            get
            {
                return cant;
            }

            set
            {
                cant = value;
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

        public decimal Prec_unit
        {
            get
            {
                return prec_unit;
            }

            set
            {
                prec_unit = value;
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

        public detalle_venta() { }
        public detalle_venta(int cant,decimal prec_unit,decimal total) {
            this.cant = Cant;
            this.prec_unit = Prec_unit;
            this.total = Total;


        }

        public detalle_venta(string cod_vnta, int cant, int cod_prod, decimal prec_unit, decimal iva, decimal descuento, decimal total)
        {
            this.Cod_vnta = cod_vnta;
            this.Cant = cant;
            this.Cod_prod = cod_prod;
            this.Prec_unit = prec_unit;
            this.Iva = iva;
            this.Descuento = descuento;
            this.Total = total;
        }
    }
}
