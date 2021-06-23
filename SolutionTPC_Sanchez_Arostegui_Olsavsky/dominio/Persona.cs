using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Persona
    {
        public int ID { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Genero { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public String Constrasena { get; set; }
        public string Celular { get; set; }
        public bool Estado { get; set; }

        public Persona()
        {
            Estado = true;
        }
    }
}
