using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Turno
    {
        public int ID { get; set; }
        public Medico medico { get; set; }
        public Paciente paciente { get; set; }
        public DateTime FechaHora { get; set; }
        public Estado estado { get; set; }
        public string Motivo { get; set; }

        public Turno()
        {
            estado = new Estado();

            medico = new Medico();

            paciente = new Paciente();
        }
    }
}
