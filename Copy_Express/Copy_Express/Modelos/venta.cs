using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
    class venta
    {
        private int cod_vnta;

        private String ced_client;
        private String ced_empl;
        private String fecha;
        private String forma_pago;
        private String est_vnta;
        private Decimal subtotal;
        private decimal iva;
        private decimal desc;
        private decimal total;
        public venta() { }

        public venta(int cod_vnta, string ced_client, string ced_empl, String fecha, string forma_pago, string est_vnta, decimal subtotal, decimal iva, decimal desc, decimal total)
        {
            this.cod_vnta = cod_vnta;
            this.ced_client = ced_client;
            this.ced_empl = ced_empl;
            this.fecha = fecha;
            this.forma_pago = forma_pago;
            this.est_vnta = est_vnta;
            this.subtotal = subtotal;
            this.iva = iva;
            this.desc = desc;
            this.total = total;
        }

        public int Cod_vnta
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

        public string Ced_client
        {
            get
            {
                return ced_client;
            }

            set
            {
                ced_client = value;
            }
        }

        public string Ced_empl
        {
            get
            {
                return ced_empl;
            }

            set
            {
                ced_empl = value;
            }
        }

        public String Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string Forma_pago
        {
            get
            {
                return forma_pago;
            }

            set
            {
                forma_pago = value;
            }
        }

        public string Est_vnta
        {
            get
            {
                return est_vnta;
            }

            set
            {
                est_vnta = value;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return subtotal;
            }

            set
            {
                subtotal = value;
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

        public decimal Desc
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
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
    }
}
