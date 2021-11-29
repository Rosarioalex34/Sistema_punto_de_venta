using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
   public class Cliente : Persona
    {
        private int cod_client;
        private String ced_cliente;

        public Cliente(){ }

       public Cliente(string nombres, string apellidos, string email, string telefono, string direccion, String ciudad) //: base(nombres, apellidos, email, telefono, direccion, passward, cod_ciu)
        {
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Email = email;
            this.Telefono = telefono;
            this.Direccion = direccion;
           // this.Passward = passward;
            this.Ciudad = ciudad;
        }

      public Cliente(int cod_client, string ced_cliente)
        {
            this.cod_client = cod_client;
            this.ced_cliente = ced_cliente;
        }

        public int Cod_client
        {
            get
            {
                return cod_client;
            }

            set
            {
                cod_client = value;
            }
        }

        public string Ced_cliente
        {
            get
            {
                return ced_cliente;
            }

            set
            {
                ced_cliente = value;
            }
        }
       
    }
}
