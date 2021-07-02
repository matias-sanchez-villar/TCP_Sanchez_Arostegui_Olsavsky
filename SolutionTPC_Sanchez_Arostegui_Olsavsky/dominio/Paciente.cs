using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace dominio
{
    public class Paciente : Persona
    {
        public int ID { get; set; }
        public ObraSocial obraSocial { get; set; }
        public string NroAfiliado { get; set; }

        public Paciente()
        {
            obraSocial = new ObraSocial();
        }
    }
}
