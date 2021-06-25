using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataAccess;

namespace negocio
{
    class N_Turno
    {
        public Turno turno { get; set; }
        public List<Turno> Lista { get; set; }

        public Paciente paciente { get; set; }
        public List<Paciente> ListaPaciente { get; set; }
        public N_Paciente n_paciente { get; set; }

        public Medico medico { get; set; }
        public List<Medico> ListaMedico { get; set; }
        public N_Medico n_medico { get; set; }
        
        public DataAcces Datos { get; set; }

        //public List<Turno> ListarTodos()
        //{
        //    Datos = new DataAcces();
        //    Lista = new List<Turno>();
        //    n_medico = new N_Medico();
        //    n_paciente = new N_Paciente();


        //    try
        //    {
        //        Datos.setearConsulta("select IDPaciente, IDMedico, FechaHora, Estado from Turno");
        //        Datos.ejecutarLectura();

        //        while (Datos.Lector.Read())
        //        {
        //            turno = new Turno();

        //            turno.paciente = n_paciente.RetornarID((int)Datos.Lector["ID"]);
        //            turno.medico = n_medico.GetMedico((int)Datos.Lector["ID"]);
        //            turno.FechaHora = (DateTime)Datos.Lector["ID"];
        //            turno.Estado = (bool)Datos.Lector["Estado"];

        //            Lista.Add(turno);
        //        }
        //        return Lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Datos.cerrarConexion();
        //    }
        //}

        //public Turno GetTurnoMPT(int IDMedico, int IDpaciente, DateTime tiempo)
        //{
        //    Datos = new DataAcces();
        //    turno = new Turno();
        //    n_medico = new N_Medico();
        //    n_paciente = new N_Paciente();

        //    /// chequear si no hay que formatear el tiempo

        //    try
        //    {
        //        Datos.setearConsulta("select IDPaciente, IDMedico, FechaHora, Estado from Turno where IDPaciente = " + IDpaciente + " and IDMedico = " + IDMedico + " and FechaHora = " + tiempo);
        //        Datos.ejecutarLectura();

        //            turno.paciente = n_paciente.RetornarID((int)Datos.Lector["IDPaciente"]);
        //            turno.medico = n_medico.GetMedico((int)Datos.Lector["IDMedico"]);
        //            turno.FechaHora = (DateTime)Datos.Lector["FechaHora"];
        //            turno.Estado = (bool)Datos.Lector["Estado"];

        //        return turno;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Datos.cerrarConexion();
        //    }
        //}


        /// Para modificar a un turno es complicado por la clave compuesta
        public void Modificar(Turno turno)
        {
            Datos = new DataAcces();

            try
            {
                Datos.setearConsulta("update Turno set IDMedico= @IDMedico, IDPaciente= @IDPaciente, Estado=@Estado where IDMedico= @IDMedico and IDPaciente= @IDPaciente");

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


        public void Insertar(Turno turno)
        {
            Datos = new DataAcces();
            try
            {
                Datos.setearConsulta("INSERT INTO Turnos(FechaHora, IDMedico, IDPaciente, Estado) VALUES(@FechaHora, @IDMedico, @IDPaciente, @Estado)");

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

        public void Eliminar(int ID)
        {
            Datos = new DataAcces();
            try
            {
                Datos.setearConsulta("INSERT INTO Turnos(FechaHora, IDMedico, IDPaciente, Estado) VALUES(@FechaHora, @IDMedico, @IDPaciente, @Estado)");

                Datos.setearParametro("@FechaHora", turno.FechaHora);
                Datos.setearParametro("@IDMedico", turno.medico.ID);
                Datos.setearParametro("@IDPaciente", turno.paciente.ID);
                Datos.setearParametro("@Estado", true);

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
    }
}
