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

        public List<Medico> Listar()
        {
            List<Medico> Lista = new List<Medico>();
            DataAcces Datos = new DataAcces();

            try
            {
                string Consulta = "22";

                Datos.setearConsulta(Consulta);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Medico medico = new Medico();

                    medico.ID = (int)Datos.Lector["ID"];
                    medico.DNI = (string)Datos.Lector["DNI"];
                    medico.Nombre = (string)Datos.Lector["Nombre"];
                    medico.Apellido = (string)Datos.Lector["Apellido"];
                    medico.Matricula = (string)Datos.Lector["Matricula"];
                    medico.Especialidad = (string)Datos.Lector["Especialidad"];
                    medico.Domicilio = (string)Datos.Lector["Domicilio"];
                    medico.Email = (string)Datos.Lector["Email"];
                    medico.Constrasena = (string)Datos.Lector["Pass"];
                    medico.Especialidad = (string)Datos.Lector["Especialidad"];
                    medico.Celular = (string)Datos.Lector["Telefono"];
                    medico.Estado = (bool)Datos.Lector["Estado"];
                    medico.FechaNacimiento = (DateTime)Datos.Lector["FechaNacimiento"]; 
                    medico.Genero = (char)Datos.Lector["Genero"];

                    Lista.Add(medico);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }

            return Lista;
        }
    }
}
