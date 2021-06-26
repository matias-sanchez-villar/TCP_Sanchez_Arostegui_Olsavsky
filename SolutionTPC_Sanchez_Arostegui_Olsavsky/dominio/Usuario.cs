using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }

        public Usuario(int _ID)
        {
            this.ID = _ID;
        }

        public Usuario(string _Email, string _Contrasena)
        {
            this.Email = _Email;
            this.Contrasena = _Contrasena;

        }

        public Usuario(bool _estado)
        {
            this.Estado = _estado;

        }

        public override string ToString()
        {
            return this.Email;
        }

    }


}
