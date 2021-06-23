using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccess;

namespace dominio
{
    public class Medico : Persona
    {
        public Persona persona { get; set; }
        public string Matricula { get; set; }
        public string Especialidad { get; set; }

    }
}
