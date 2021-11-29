using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
    public class Usuario : Persona
    {
        private int cod_usua;
        private String rol;
        private String ced_usua;
        private String passward;
        private int aux;
        public Usuario() { }

        public Usuario(int cod_usua, string rol, string ced_usua, string passward,int aux)
        {
            this.cod_usua = cod_usua;
            this.rol = rol;
            this.ced_usua = ced_usua;
            this.passward = passward;
            this.Aux = aux;
        }

        public int Cod_usua
        {
            get
            {
                return cod_usua;
            }

            set
            {
                cod_usua = value;
            }
        }

        public string Rol
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
            }
        }

        public string Ced_usua
        {
            get
            {
                return ced_usua;
            }

            set
            {
                ced_usua = value;
            }
        }

        public string Passward
        {
            get
            {
                return passward;
            }

            set
            {
                passward = value;
            }
        }

        public int Aux
        {
            get
            {
                return aux;
            }

            set
            {
                aux = value;
            }
        }
    }
}
