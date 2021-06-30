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
                string Select = " SELECT M.ID, M.Apellido, M.Nombre, M.FechaNacimiento, M.Domicilio, M.Celular, M.Genero, M.Matricula, U.Email, U.Estado, E.Especialidad ";
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
                    medico.Usuario.Email = (string)Datos.Lector["Email"];
                    medico.Especialidad = (string)Datos.Lector["Especialidad"];

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

            try
            {
                string Select = " SELECT M.ID, M.Apellido, M.Nombre, M.FechaNacimiento, M.Domicilio, M.Celular, M.Genero, M.Matricula, U.Email, U.Estado, E.Especialidad ";
                string From = " FROM Medicos M ";
                string JoinU = " inner join Usuarios U on M.IDUsuario = U.ID ";
                string JoinE = " inner join Especialidades E on E.ID = M.IDEspecialidad ";
                string Where = " where U.Estado = 1 and M.ID = " + ID;
                string query = Select + From + JoinU + JoinE + Where;

                Datos.setearConsulta(query);
                Datos.ejecutarLectura();

                    Medico medico = new Medico();

                    medico.ID = (int)Datos.Lector["ID"];
                    medico.Apellido = (string)Datos.Lector["Apellido"];
                    medico.Nombre = (string)Datos.Lector["Nombre"];
                    medico.FechaNacimiento = (DateTime)Datos.Lector["FechaNacimiento"];
                    medico.Domicilio = (string)Datos.Lector["Domicilio"];
                    medico.Celular = (string)Datos.Lector["Celular"];
                    medico.Genero = (string)Datos.Lector["Genero"];
                    medico.Matricula = (string)Datos.Lector["Matricula"];
                    medico.Usuario.Email = (string)Datos.Lector["Email"];
                    medico.Especialidad = (string)Datos.Lector["Especialidad"];

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
                Datos.setearParametro("@IDUsuario", usuario.Cargar(medico.Usuario));
                
                ///Datos.setearParametro("@IDEspecialidad", medico.Especialidad); es un int de ID y carga un string/varchar

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

        //public void Modificar(Medico medico)
        //{
        //    Datos = new DataAcces();
        //    try
        //    {   /*Arreglar el seteo con los nuevos tipos de datos*/
        //        Datos.setearConsulta("update Medicos set Nombre = @Nombre, Apellido = @Apellido, Domicilio = @Domicilio, EMail = @EMail, Contrasena = @Contrasena, Celular = @Celular, Especialidad = @Especialidad, Matricula = @Matricula where ID = @ID");

        //        //Agregar dentro del formulario correspondiente los datos que vienen del médico especifico
        //        Datos.setearParametro("@ID", medico.ID);
        //        Datos.setearParametro("@Apellido", medico.Apellido);
        //        Datos.setearParametro("@Celular", medico.Celular);
        //        Datos.setearParametro("@Domicilio", medico.Domicilio);
        //        Datos.setearParametro("@Email", medico.Email);
        //        Datos.setearParametro("@Especialidad", medico.Especialidad);
        //        Datos.setearParametro("@FechaNacimiento", medico.FechaNacimiento);
        //        Datos.setearParametro("@Matricula", medico.Matricula);
        //        Datos.setearParametro("@Nombre", medico.Nombre);

        //        Datos.EjecutarAccion();
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
       

        //public void Eliminar(int ID)
        //{
        //    Datos = new DataAcces();
        //    try
        //    {
        //        Datos.setearConsulta("update Medicos set Estado = @Estado where ID = @ID");

        //        Datos.setearParametro("@ID", ID);
        //        Datos.setearParametro("@Estado", false);

        //        Datos.EjecutarAccion();
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
    }
}
