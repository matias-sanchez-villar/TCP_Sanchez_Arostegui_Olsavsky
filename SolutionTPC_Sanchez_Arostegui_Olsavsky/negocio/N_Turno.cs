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

        public List<Turno> ListarIDMedico(int ID)
        {
            Datos = new DataAcces();
            Lista = new List<Turno>();

            medico = new N_Medico();
            paciente = new N_Paciente();

            try
            {
                string query = (" select ID, Fecha, Hora, IDMedico, IDPaciente, Estado from Turnos where IDMedico = @ID ");

                Datos.setearConsulta(query);

                Datos.setearParametro("@ID", ID);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Turno turno = new Turno();

                    turno.ID = (int)Datos.Lector["ID"];
                    turno.Fecha = (DateTime)Datos.Lector["Fecha"];
                    turno.Hora = (TimeSpan)Datos.Lector["Hora"];
                    turno.medico = (Medico)medico.BuscarMedicoID(turno.medico.ID = (int)Datos.Lector["IDMedico"]);
                    turno.paciente = (Paciente)paciente.BuscarPacienteID(turno.paciente.ID = (int)Datos.Lector["IDPaciente"]);
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

        public List<Turno> ListarIDPaciente(int ID)
        {
            Datos = new DataAcces();
            Lista = new List<Turno>();

            medico = new N_Medico();
            paciente = new N_Paciente();

            try
            {
                string query = (" select ID, Fecha, Hora, IDMedico, IDPaciente, Estado from Turnos where IDPaciente = @ID ");

                Datos.setearConsulta(query);

                Datos.setearParametro("@ID", ID);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Turno turno = new Turno();

                    turno.ID = (int)Datos.Lector["ID"];
                    turno.Fecha = (DateTime)Datos.Lector["Fecha"];
                    turno.Hora = (TimeSpan)Datos.Lector["Hora"];
                    turno.medico = (Medico)medico.BuscarMedicoID(turno.medico.ID = (int)Datos.Lector["IDMedico"]);
                    turno.paciente = (Paciente)paciente.BuscarPacienteID(turno.paciente.ID = (int)Datos.Lector["IDPaciente"]);
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

        public Turno ListarID(int ID)
        {
            Datos = new DataAcces();

            medico = new N_Medico();

            paciente = new N_Paciente();

            try
            {
                string query = (" select ID, Fecha, Hora, IDMedico, IDPaciente, Estado from Turnos where ID = " + ID );

                Datos.setearConsulta(query);

                Datos.ejecutarLectura();

                Datos.Lector.Read();

                    Turno turno = new Turno();

                    turno.ID = (int)Datos.Lector["ID"];
                    turno.Fecha = (DateTime)Datos.Lector["Fecha"];
                    turno.Hora = (TimeSpan)Datos.Lector["Hora"];
                    turno.medico = (Medico)medico.BuscarMedicoID(turno.medico.ID = (int)Datos.Lector["IDMedico"]);
                    turno.paciente = (Paciente)paciente.BuscarPacienteID(turno.paciente.ID = (int)Datos.Lector["IDPaciente"]);
                    turno.Estado = (string)Datos.Lector["Estado"];

                 
                return turno;
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

        public List<Turno> ListarIDMedicoFecha(int ID, DateTime Fecha)
        {
            Datos = new DataAcces();
            Lista = new List<Turno>();

            medico = new N_Medico();
            paciente = new N_Paciente();

            try
            {
                string query = (" select ID, Fecha, Hora, IDMedico, IDPaciente, Estado from Turnos where IDMedico = @ID and Fecha = @Fecha ");

                Datos.setearConsulta(query);

                Datos.setearParametro("@ID", ID);
                Datos.setearParametro("@Fecha", Fecha);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Turno turno = new Turno();

                    turno.ID = (int)Datos.Lector["ID"];
                    turno.Fecha = (DateTime)Datos.Lector["Fecha"];
                    turno.Hora = (TimeSpan)Datos.Lector["Hora"];
                    turno.medico = (Medico)medico.BuscarMedicoID(turno.medico.ID = (int)Datos.Lector["IDMedico"]);
                    turno.paciente = (Paciente)paciente.BuscarPacienteID(turno.paciente.ID = (int)Datos.Lector["IDPaciente"]);
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

        public void Cargar(Turno Turno)
        {
            Datos = new DataAcces();
            
            try
            {
                
                Datos.setearConsulta(" insert into Turnos(Fecha, Hora, IDMedico, IDPaciente, Estado) values (@Fecha, @Hora, @IDMedico, @IDPaciente, @Estado) ");

               
                Datos.setearParametro("@Fecha", Turno.Fecha);
                Datos.setearParametro("@Hora", Turno.Hora);
                Datos.setearParametro("@IDMedico", Turno.medico.ID);
                Datos.setearParametro("@IDPaciente", Turno.paciente.ID);
                Datos.setearParametro("@Estado", Turno.Estado);
               
                Datos.EjecutarAccion();

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

        public void Eliminar(int IDTurno)
        {
            Datos = new DataAcces();
            try
            {
                //Datos.setearConsulta(" Delete Turnos where ID = @ID");
                Datos.setearConsulta(" UPDATE Turnos set Estado = 'Cancelado' where ID = @ID");

                Datos.setearParametro("@ID", IDTurno);

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

        public void Modificar(Turno turno)
        {
            Datos = new DataAcces();

            try
            {

                Datos.setearConsulta(" update Turnos set Fecha = @Fecha, Hora = @Hora, Estado = @Estado where ID = @ID ");

                Datos.setearParametro("@ID", turno.ID);
                Datos.setearParametro("@Fecha", turno.Fecha);
                Datos.setearParametro("@Hora", turno.Hora);
                Datos.setearParametro("@Estado", turno.Estado);

                Datos.EjecutarAccion();

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

        public string EmailPaciente(Turno turnoAux)
        {
            Datos = new DataAcces();

            medico = new N_Medico();
            paciente = new N_Paciente();

            try
            {
                string query = (" select U.Email from Usuarios U inner join Pacientes P on P.IDUsuario = U.ID where P.ID = @IDPaciente");
                string email = "";

                Datos.setearConsulta(query);

                Datos.setearParametro("@IDPaciente", turnoAux.paciente.ID);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    
                    email = (string)Datos.Lector["Email"];

                   
                }
                return email;
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
