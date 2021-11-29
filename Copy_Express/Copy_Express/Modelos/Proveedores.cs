using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
   public  class proveedores 
    {
        private int cod_prov;
        private String ruc_ced;
        private String nom_prv;
        private String direcc;
        private String ciudad;
        private String telf;
        private String email;

        public int Cod_prov
        {
            get
            {
                return cod_prov;
            }

            set
            {
                cod_prov = value;
            }
        }

        public string Ruc_ced
        {
            get
            {
                return ruc_ced;
            }

            set
            {
                ruc_ced = value;
            }
        }

        public string Nom_prv
        {
            get
            {
                return nom_prv;
            }

            set
            {
                nom_prv = value;
            }
        }

        public string Direcc
        {
            get
            {
                return direcc;
            }

            set
            {
                direcc = value;
            }
        }

        public string Ciudad1
        {
            get
            {
                return ciudad;
            }

            set
            {
                ciudad = value;
            }
        }

        public string Telf
        {
            get
            {
                return telf;
            }

            set
            {
                telf = value;
            }
        }

        public string Email1
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public proveedores()
        {
           
        }

        public proveedores(int cod_prov, string ruc_ced, string nom_prv, string direcc, string ciudad, string telf, string email)
        {
            this.Cod_prov = cod_prov;
            this.Ruc_ced = ruc_ced;
            this.Nom_prv = nom_prv;
            this.Direcc = direcc;
            this.Ciudad1 = ciudad;
            this.Telf = telf;
            this.Email1 = email;
        }
    }
}
