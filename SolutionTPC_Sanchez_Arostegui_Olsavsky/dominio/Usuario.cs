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

        public Usuario()
        {
            Estado = true;
        }

    }


}
