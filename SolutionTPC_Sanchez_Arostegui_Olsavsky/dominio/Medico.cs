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
        public int ID { get; set; }
        public Especialidad especialidad { get; set; }
        public string Matricula { get; set; }

        public Medico()
        {
            especialidad = new Especialidad();
        }
    }
}
