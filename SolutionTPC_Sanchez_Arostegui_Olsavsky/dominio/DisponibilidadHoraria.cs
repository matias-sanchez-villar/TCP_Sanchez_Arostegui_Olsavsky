using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DisponibilidadHoraria
    {
        public int ID { get; set; }
        public Medico medicoAux { get; set; }
        public string Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Estado { get; set; }

        public DisponibilidadHoraria()
        {
            this.Estado = true;
        }
    }
}
