using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Turno
    {
        public Medico medico { get; set; }
        public Paciente paciente { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
