using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Medico : Persona
    {
        public string ObraSocial { get; set; }
        public string NumeroAfiliado { get; set; }
        public Persona persona { get; set; }

        public Medico(Persona persona)
        {
            this.persona = persona;
        }
    }
}
