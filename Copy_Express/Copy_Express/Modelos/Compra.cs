using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
   public class Compra
    {
        private int cod_compr;
        private String ced_ruc_prov;
        private String ced_empl;
        private String fecha_pedido;
        private String fecha_entrega;
       // private String forma_pago;
        private String est_compr;
        private decimal subtotal;
        private decimal iva;
        private decimal desc;
        private decimal total;

        public int Cod_compr
        {
            get
            {
                return cod_compr;
            }

            set
            {
                cod_compr = value;
            }
        }

        public string Ced_ruc_prov
        {
            get
            {
                return ced_ruc_prov;
            }

            set
            {
                ced_ruc_prov = value;
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

        public String Fecha_pedido
        {
            get
            {
                return fecha_pedido;
            }

            set
            {
                fecha_pedido = value;
            }
        }

        public String Fecha_entrega
        {
            get
            {
                return fecha_entrega;
            }

            set
            {
                fecha_entrega = value;
            }
        }

        public string Est_compr
        {
            get
            {
                return est_compr;
            }

            set
            {
                est_compr = value;
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
        public Compra() { }
        public Compra(int cod_compr, string ced_ruc_prov, string ced_empl, String fecha_pedido, String fecha_entrega, string est_compr, decimal subtotal, decimal iva, decimal desc, decimal total)
        {
            this.Cod_compr = cod_compr;
            this.Ced_ruc_prov = ced_ruc_prov;
            this.Ced_empl = ced_empl;
            this.Fecha_pedido = fecha_pedido;
            this.Fecha_entrega = fecha_entrega;
            this.Est_compr = est_compr;
            this.Subtotal = subtotal;
            this.Iva = iva;
            this.Desc = desc;
            this.Total = total;
        }
    }
}
