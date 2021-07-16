using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataAccess;

namespace negocio
{
    public class N_DisponibilidadHoraria
    {
        public DataAcces Datos = new DataAcces();
        public DisponibilidadHoraria disponibilidad = new DisponibilidadHoraria();
        public List<DisponibilidadHoraria> Lista = new List<DisponibilidadHoraria>();

        public List<DisponibilidadHoraria> Listar()
        {
            N_Medico NMedicoAux = new N_Medico();
            try
            {
                Datos.setearConsulta(" select ID, IDMedico, Dia, HorarioInicio, HorarioFin, Estado from DisponibilidadHoraria ");
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    DisponibilidadHoraria Disponibilidad = new DisponibilidadHoraria();

                    Disponibilidad.ID = (int)Datos.Lector["ID"];
                    Disponibilidad.medicoAux = NMedicoAux.BuscarMedicoID((int)Datos.Lector["IDMedico"]);
                    Disponibilidad.Dia = (string)Datos.Lector["Dia"];
                    Disponibilidad.HoraInicio = (TimeSpan)Datos.Lector["HorarioInicio"];
                    Disponibilidad.HoraFin = (TimeSpan)Datos.Lector["HorarioFin"];
                    Disponibilidad.Estado = (bool)Datos.Lector["Estado"];

                    Lista.Add(Disponibilidad);
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

        public List<DisponibilidadHoraria> ListarIDMedico(int ID)
        {
            N_Medico NMedicoAux = new N_Medico();
            try
            {
                Datos.setearConsulta(" select ID, IDMedico, Dia, HorarioInicio, HorarioFin, Estado from DisponibilidadHoraria where IDMedico = @ID ");

                Datos.setearParametro("@ID", ID);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    DisponibilidadHoraria Disponibilidad = new DisponibilidadHoraria();

                    Disponibilidad.ID = (int)Datos.Lector["ID"];
                    Disponibilidad.medicoAux = NMedicoAux.BuscarMedicoID((int)Datos.Lector["IDMedico"]);
                    Disponibilidad.Dia = (string)Datos.Lector["Dia"];
                    Disponibilidad.HoraInicio = (TimeSpan)Datos.Lector["HorarioInicio"];
                    Disponibilidad.HoraFin = (TimeSpan)Datos.Lector["HorarioFin"];
                    Disponibilidad.Estado = (bool)Datos.Lector["Estado"];

                    Lista.Add(Disponibilidad);
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

        public void Cargar(DisponibilidadHoraria disponibilidad)
        {

            try
            {

                Datos.setearConsulta(" insert into DisponibilidadHoraria (IDMedico, Dia, HorarioInicio, HorarioFin, Estado) values (@IDMedico, @Dia, @HorarioInicio, @HorarioFin, @Estado)");

                Datos.setearParametro("@IDMedico", disponibilidad.medicoAux.ID);
                Datos.setearParametro("@Dia", disponibilidad.Dia);
                Datos.setearParametro("@HorarioInicio", disponibilidad.HoraInicio);
                Datos.setearParametro("@HorarioFin", disponibilidad.HoraFin);
                Datos.setearParametro("@Estado", disponibilidad.Estado);

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

        public void Modificar(DisponibilidadHoraria disponibilidad)
        {
            try
            {

                Datos.setearConsulta(" update DisponibilidadHoraria set IDMedico = @IDMedico, Dia = @Dia, HorarioInicio = @HorarioInicio, HorarioFin = @HorarioFin, Estado = @Estado ");

                Datos.setearParametro("@IDMedico", disponibilidad.medicoAux.ID);
                Datos.setearParametro("@Dia", disponibilidad.Dia);
                Datos.setearParametro("@HorarioInicio", disponibilidad.HoraInicio);
                Datos.setearParametro("@HorarioFin", disponibilidad.HoraFin);
                Datos.setearParametro("@Estado", disponibilidad.Estado);

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

        public void Eliminar(DisponibilidadHoraria disponibilidad)
        {
            try
            {

                Datos.setearConsulta(" delete from DisponibilidadHoraria where ID = @ID ");

                Datos.setearParametro("@ID", disponibilidad.ID);
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
