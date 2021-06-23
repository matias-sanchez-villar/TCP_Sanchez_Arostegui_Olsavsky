using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataAccess;

namespace negocio
{
    public class N_Medico
    {
        public Medico Medico { get; set; }
        public List<Medico> Lista { get; set; }
        public DataAcces Datos { get; set; }

        public N_Medico()
        {
            Datos = new DataAcces();
        }

        public List<Medico> Listar()
        {
            Lista = new List<Medico>();

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
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }
    }
}
