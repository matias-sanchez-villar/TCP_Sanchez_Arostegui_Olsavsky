using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Paciente : Persona
    {
        public Persona persona { get; set; }
        public string ObraSocial { get; set; }
        public string NumeroAfiliado { get; set; }

    }
}
