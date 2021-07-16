using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataAccess;

namespace negocio
{
    public class N_Turno
    {
        public Turno turno { get; set; }
        public List<Turno> Lista { get; set; }
        public DataAcces Datos { get; set; }

        public N_Medico medico { get; set; }

        public N_Paciente paciente { get; set; }

        public List<Turno> Listar()
        {
            Datos = new DataAcces();
            Lista = new List<Turno>();

            medico = new N_Medico();
            paciente = new N_Paciente();

            try
            {
               string query = (" select ID, Fecha, Hora, IDMedico, IDPaciente, Estado from Turnos ");

                Datos.setearConsulta(query);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Turno turno = new Turno();

                    turno.ID = (int)Datos.Lector["ID"];
                    turno.Fecha = (DateTime)Datos.Lector["Fecha"];
                    turno.Hora = (TimeSpan)Datos.Lector["Hora"];
                    turno.medico = (Medico)medico.BuscarMedicoID ( turno.medico.ID = (int)Datos.Lector["IDMedico"] );
                    turno.paciente = (Paciente)paciente.BuscarPacienteID ( turno.paciente.ID = (int)Datos.Lector["IDPaciente"] );
                    turno.Estado = (string)Datos.Lector["Estado"];

                    Lista.Add(turno);
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

        public void Eliminar(Turno turno)
        {
            Datos = new DataAcces();
            try
            {
                Datos.setearConsulta(" Delete Turnos where ID = @ID");

                Datos.setearParametro("@FechaHora", turno.ID);

                Datos.ejecutarLectura();

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
