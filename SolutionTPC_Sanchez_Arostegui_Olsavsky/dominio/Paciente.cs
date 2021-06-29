using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Paciente : Persona
    {
        public int ID { get; set; }
        public string ObraSocial { get; set; }
        public string NroAfiliado { get; set; }
    }
}
