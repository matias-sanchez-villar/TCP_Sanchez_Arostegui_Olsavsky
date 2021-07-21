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

        List<Medico> Lista;
        DataAcces Datos;

        public List<Medico> Listar()
        {
            Lista = new List<Medico>();
            Datos = new DataAcces();

            try
            {
                string Select = " SELECT M.ID, M.Apellido, M.Nombre, M.FechaNacimiento, M.Domicilio, M.Celular, M.Genero, M.Matricula, U.Email, U.Estado, E.Especialidad, u.Contrasena, u.ID as IDUsuario, e.ID as IDEspecialidad ";
                string From = " FROM Medicos M ";
                string JoinU = " inner join Usuarios U on M.IDUsuario = U.ID ";
                string JoinE = " inner join Especialidades E on E.ID = M.IDEspecialidad ";
                string Where = " where U.Estado = 1 ";
                string query = Select + From + JoinU + JoinE + Where;

                Datos.setearConsulta(query);
                Datos.ejecutarLectura();

                while(Datos.Lector.Read())
                {
                    Medico medico = new Medico();

                    medico.ID = (int)Datos.Lector["ID"];
                    medico.Apellido = (string)Datos.Lector["Apellido"];
                    medico.Nombre = (string)Datos.Lector["Nombre"];
                    medico.FechaNacimiento = (DateTime)Datos.Lector["FechaNacimiento"];
                    medico.Domicilio = (string)Datos.Lector["Domicilio"];
                    medico.Celular = (string)Datos.Lector["Celular"];
                    medico.Genero = (string)Datos.Lector["Genero"];
                    medico.Matricula = (string)Datos.Lector["Matricula"];
                    medico.Usuario.ID = (int)Datos.Lector["IDUsuario"];
                    medico.Usuario.Contrasena = (string)Datos.Lector["Contrasena"];
                    medico.Usuario.Email = (string)Datos.Lector["Email"];
                    medico.especialidad.ID = (int)Datos.Lector["IDEspecialidad"];
                    medico.especialidad.Nombre = (string)Datos.Lector["Especialidad"];

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

        public Medico BuscarMedicoID(int ID)
        {
            Datos = new DataAcces();

            Medico medico = new Medico();

            try
            {
                string Select = " SELECT M.ID, M.Apellido, M.Nombre, M.FechaNacimiento, M.Domicilio, M.Celular, M.Genero, M.Matricula, U.Email, U.Estado, E.Especialidad ";
                string From = " FROM Medicos M ";
                string JoinU = " inner join Usuarios U on M.IDUsuario = U.ID ";
                string JoinE = " inner join Especialidades E on E.ID = M.IDEspecialidad ";
                string Where = " where U.Estado = 1 and M.ID = @ID ";
                string query = Select + From + JoinU + JoinE + Where;

                Datos.setearConsulta(query);

                Datos.setearParametro("@ID", ID);

                Datos.ejecutarLectura();

                Datos.Lector.Read();

                    medico.ID = (int)Datos.Lector["ID"];
                    medico.Apellido = (string)Datos.Lector["Apellido"];
                    medico.Nombre = (string)Datos.Lector["Nombre"];
                    medico.FechaNacimiento = (DateTime)Datos.Lector["FechaNacimiento"];
                    medico.Domicilio = (string)Datos.Lector["Domicilio"];
                    medico.Celular = (string)Datos.Lector["Celular"];
                    medico.Genero = (string)Datos.Lector["Genero"];
                    medico.Matricula = (string)Datos.Lector["Matricula"];
                    medico.Usuario.Email = (string)Datos.Lector["Email"];
                    medico.especialidad.Nombre = (string)Datos.Lector["Especialidad"];

                return medico;
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

        public List<Medico> ListarEspecialidad(int Especialidad)
        {
            Lista = new List<Medico>();
            Datos = new DataAcces();

            try
            {
                string Select = " SELECT M.ID, M.Apellido, M.Nombre, M.FechaNacimiento, M.Domicilio, M.Celular, M.Genero, M.Matricula, U.Email, U.Estado, E.Especialidad, u.Contrasena, u.ID as IDUsuario, e.ID as IDEspecialidad ";
                string From = " FROM Medicos M ";
                string JoinU = " inner join Usuarios U on M.IDUsuario = U.ID ";
                string JoinE = " inner join Especialidades E on E.ID = M.IDEspecialidad ";
                string Where = " where U.Estado = 1 and  E.ID = " + Especialidad;
                string query = Select + From + JoinU + JoinE + Where;

                Datos.setearConsulta(query);
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Medico medico = new Medico();

                    medico.ID = (int)Datos.Lector["ID"];
                    medico.Apellido = (string)Datos.Lector["Apellido"];
                    medico.Nombre = (string)Datos.Lector["Nombre"];
                    medico.FechaNacimiento = (DateTime)Datos.Lector["FechaNacimiento"];
                    medico.Domicilio = (string)Datos.Lector["Domicilio"];
                    medico.Celular = (string)Datos.Lector["Celular"];
                    medico.Genero = (string)Datos.Lector["Genero"];
                    medico.Matricula = (string)Datos.Lector["Matricula"];
                    medico.Usuario.ID = (int)Datos.Lector["IDUsuario"];
                    medico.Usuario.Contrasena = (string)Datos.Lector["Contrasena"];
                    medico.Usuario.Email = (string)Datos.Lector["Email"];
                    medico.especialidad.ID = (int)Datos.Lector["IDEspecialidad"];
                    medico.especialidad.Nombre = (string)Datos.Lector["Especialidad"];

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

        public void Cargar(Medico medico)
        {
            Datos = new DataAcces();

            N_Usuario usuario = new N_Usuario();
            try
            {

                Datos.setearConsulta(" insert into Medicos(Nombre, Apellido, Domicilio, Celular, FechaNacimiento, Genero, Matricula, IDUsuario, IDEspecialidad) values (@Nombre, @Apellido, @Domicilio, @Celular, @FechaNacimiento, @Genero, @Matricula, @IDUsuario, @IDEspecialidad) ");

                Datos.setearParametro("@Nombre", medico.Nombre);
                Datos.setearParametro("@Apellido", medico.Apellido);
                Datos.setearParametro("@Domicilio", medico.Domicilio);
                Datos.setearParametro("@Celular", medico.Celular);
                Datos.setearParametro("@FechaNacimiento", medico.FechaNacimiento);
                Datos.setearParametro("@Genero", medico.Genero);
                Datos.setearParametro("@Matricula", medico.Matricula);

                medico.Usuario.tipoUsuario = 1;
                usuario.Cargar(medico.Usuario);
                medico.Usuario.ID = usuario.RetornarID(medico.Usuario.Email);

                Datos.setearParametro("@IDUsuario", medico.Usuario.ID);
                
                Datos.setearParametro("@IDEspecialidad", medico.especialidad.ID);

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

        public void Modificar(Medico medico)
        {
            Datos = new DataAcces();

            N_Usuario usuario = new N_Usuario();
            try
            {

                Datos.setearConsulta(" update Medicos set Nombre = @Nombre, Apellido = @Apellido, Domicilio = @Domicilio, Celular = @Celular, FechaNacimiento = @FechaNacimiento, Genero = @Genero, Matricula = @Matricula, IDEspecialidad = @IDEspecialidad where ID = @ID ");

                Datos.setearParametro("@ID", medico.ID);
                Datos.setearParametro("@Nombre", medico.Nombre);
                Datos.setearParametro("@Apellido", medico.Apellido);
                Datos.setearParametro("@Domicilio", medico.Domicilio);
                Datos.setearParametro("@Celular", medico.Celular);
                Datos.setearParametro("@FechaNacimiento", medico.FechaNacimiento);
                Datos.setearParametro("@Genero", medico.Genero);
                Datos.setearParametro("@Matricula", medico.Matricula);

                usuario.Modificar(medico.Usuario);

                Datos.setearParametro("@IDEspecialidad", medico.especialidad.ID);

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

        public void Eliminar(Medico medico)
        {
            try
            {
                Datos = new DataAcces();

                Datos.setearConsulta("Delete from Medicos where ID = @ID ");

                Datos.setearParametro("@ID", medico.ID);

                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Medico BuscarMedicoIDUsuario(Usuario aux)
        {
            Datos = new DataAcces();

            Medico medico = new Medico();

            try
            {
                string Select = " SELECT M.ID, M.Apellido, M.Nombre, M.FechaNacimiento, M.Domicilio, M.Celular, M.Genero, M.Matricula, U.Email, U.Estado, E.Especialidad, U.Contrasena ";
                string From = " FROM Medicos M ";
                string JoinU = " inner join Usuarios U on M.IDUsuario = U.ID ";
                string JoinE = " inner join Especialidades E on E.ID = M.IDEspecialidad ";
                string Where = " where U.Estado = 1 and U.ID = @ID ";
                string query = Select + From + JoinU + JoinE + Where;

                Datos.setearConsulta(query);

                Datos.setearParametro("@ID", aux.ID);

                Datos.ejecutarLectura();

                Datos.Lector.Read();

                medico.ID = (int)Datos.Lector["ID"];
                medico.Apellido = (string)Datos.Lector["Apellido"];
                medico.Nombre = (string)Datos.Lector["Nombre"];
                medico.FechaNacimiento = (DateTime)Datos.Lector["FechaNacimiento"];
                medico.Domicilio = (string)Datos.Lector["Domicilio"];
                medico.Celular = (string)Datos.Lector["Celular"];
                medico.Genero = (string)Datos.Lector["Genero"];
                medico.Matricula = (string)Datos.Lector["Matricula"];
                medico.Usuario.Email = (string)Datos.Lector["Email"];
                medico.Usuario.Contrasena = (string)Datos.Lector["Contrasena"];
                medico.especialidad.Nombre = (string)Datos.Lector["Especialidad"];

                return medico;
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
