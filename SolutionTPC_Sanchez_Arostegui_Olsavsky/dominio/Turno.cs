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
        public int Estado { get; set; }   /*0=turno no-vigente-cancelado, 
                                            1=turno vigente-agendado,
                                            2=Asistió al turno
                                            3=Turno-Re-Agendado
                                            4=Faltó al turno
                                            */
   
        public Turno()
        {
            Estado = 1;

            medico = new Medico();

            paciente = new Paciente();
        }
    }
}
