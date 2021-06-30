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
                string query = (" select ID, FechaHora, IDMedico, IDPaciente, Estado from Turnos ");

                Datos.setearConsulta(query);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Turno turno = new Turno();

                    turno.ID = (int)Datos.Lector["ID"];
                    turno.FechaHora = (DateTime)Datos.Lector["FechaHora"];
                    turno.medico = (Medico)medico.BuscarMedicoID ( turno.medico.ID = (int)Datos.Lector["IDMedico"] );
                    turno.paciente = (Paciente)paciente.BuscarPacienteID ( turno.paciente.ID = (int)Datos.Lector["IDPaciente"] );
                    turno.Estado = (int)Datos.Lector["Estado"];

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

        public List<Turno> ListarMedicoID(int ID)
        {
            Datos = new DataAcces();
            Lista = new List<Turno>();

            medico = new N_Medico();
            paciente = new N_Paciente();

            try
            {
                string query = (" select ID, FechaHora, IDMedico, IDPaciente, Estado from Turnos where IDMedico =  " + ID);

                Datos.setearConsulta(query);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Turno turno = new Turno();

                    turno.ID = (int)Datos.Lector["ID"];
                    turno.FechaHora = (DateTime)Datos.Lector["FechaHora"];
                    turno.medico = (Medico)medico.BuscarMedicoID(turno.medico.ID = (int)Datos.Lector["IDMedico"]);
                    turno.paciente = (Paciente)paciente.BuscarPacienteID(turno.paciente.ID = (int)Datos.Lector["IDPaciente"]);
                    turno.Estado = (int)Datos.Lector["Estado"];

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

        public List<Turno> ListarPacienteID(int ID)
        {
            Datos = new DataAcces();
            Lista = new List<Turno>();

            medico = new N_Medico();
            paciente = new N_Paciente();

            try
            {
                string query = (" select ID, FechaHora, IDMedico, IDPaciente, Estado from Turnos where IDPaciente =  " + ID);

                Datos.setearConsulta(query);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Turno turno = new Turno();

                    turno.ID = (int)Datos.Lector["ID"];
                    turno.FechaHora = (DateTime)Datos.Lector["FechaHora"];
                    turno.medico = (Medico)medico.BuscarMedicoID(turno.medico.ID = (int)Datos.Lector["IDMedico"]);
                    turno.paciente = (Paciente)paciente.BuscarPacienteID(turno.paciente.ID = (int)Datos.Lector["IDPaciente"]);
                    turno.Estado = (int)Datos.Lector["Estado"];

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

        public void Cargar(Turno turno)
        {
            Datos = new DataAcces();
            try
            {
                Datos.setearConsulta(" insert into Turnos (FechaHora, IDMedico, IDPaciente, Estado) values (@FechaHora, @IDMedico, @IDPaciente, @Estado) ");

                Datos.setearParametro("@FechaHora", turno.FechaHora);
                Datos.setearParametro("@IDMedico", turno.medico.ID);
                Datos.setearParametro("@IDPaciente", turno.paciente.ID);
                Datos.setearParametro("@Estado", true);

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
