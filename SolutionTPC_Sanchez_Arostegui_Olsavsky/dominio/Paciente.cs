using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using Dominio;

namespace dominio
{
    public class Paciente : Persona
    {
        public int ID { get; set; }
        public ObraSocial obraSoc { get; set; }
        public string NroAfiliado { get; set; }

        public Paciente()
        {
            obraSoc = new ObraSocial();
        }
    }
}
