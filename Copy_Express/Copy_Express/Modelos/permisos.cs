using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Express.Clases
{
    public class permisos
    {
        private String ced_usua;
        private int update;
        private int insert;
        private int delete;

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

        public int Update
        {
            get
            {
                return update;
            }

            set
            {
                update = value;
            }
        }

        public int Insert
        {
            get
            {
                return insert;
            }

            set
            {
                insert = value;
            }
        }

        public int Delete
        {
            get
            {
                return delete;
            }

            set
            {
                delete = value;
            }
        }
        public permisos() { }
        public permisos(string ced_usua, int update, int insert, int delete)
        {
            this.ced_usua = ced_usua;
            this.update = update;
            this.insert = insert;
            this.delete = delete;
        }
    }
}
