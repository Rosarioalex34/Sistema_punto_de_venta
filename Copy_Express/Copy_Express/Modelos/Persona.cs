using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
 public   class Persona
    {
        private String nombres;
        private String apellidos;
        private String email;
        private String telefono;
        private String direccion;
        private String ciudad;
        public Persona(string nombres, string apellidos, string email, string telefono, string direccion,  String ciudad)
        {
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Email = email;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Ciudad = ciudad;
        }

        public Persona()
        {
        }

        public string Nombres
        {
            get
            {
                return nombres;
            }

            set
            {
                nombres = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return apellidos;
            }

            set
            {
                apellidos = value;
            }
        }

        public string Email
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

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Ciudad
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
    }
}
