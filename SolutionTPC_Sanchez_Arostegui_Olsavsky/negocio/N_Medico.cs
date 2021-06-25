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
        public DataAcces Datos = new DataAcces();
        public List<Medico> Lista = new List<Medico>();

        public List<Medico> Listar()
        {

            try
            {
                Datos.setearConsulta("SELECT ID, Apellido, Nombre, Email, Celular, NroMatricula, Especialidad, Genero, Estado FROM Medicos");
                Datos.ejecutarLectura();

                while(Datos.Lector.Read())
                {
                    Medico medico = new Medico();

                    medico.Nombre = (string)Datos.Lector["Nombre"];
                    medico.Apellido = (string)Datos.Lector["Apellido"];
                    medico.ID = (long)Datos.Lector["ID"];
                    medico.Email = (string)Datos.Lector["EMail"];
                    medico.Celular = (string)Datos.Lector["Celular"];
                    medico.Matricula = (string)Datos.Lector["NroMatricula"];
                    medico.Especialidad = (string)Datos.Lector["Especialidad"];
                    medico.Genero = (string)Datos.Lector["Genero"];
                    medico.Estado = (bool)Datos.Lector["Estado"];

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

        public Medico GetMedico(int ID)
        {
            Datos = new DataAcces();
            Medico medico = new Medico();

            try
            {
                Datos.setearConsulta("SELECT ID, Apellido, Nombre, Email, Celular, NroMatricula, Especialidad, Genero, Estado FROM Medicos");

                Datos.ejecutarLectura();
                
                medico = new Medico();

                medico.Nombre = (string)Datos.Lector["Nombre"];
                medico.Apellido = (string)Datos.Lector["Apellido"];
                medico.ID = (long)Datos.Lector["ID"];
                medico.Email = (string)Datos.Lector["EMail"];
                medico.Celular = (string)Datos.Lector["Celular"];
                medico.Matricula = (string)Datos.Lector["NroMatricula"];
                medico.Especialidad = (string)Datos.Lector["Especialidad"];
                medico.Genero = (string)Datos.Lector["Genero"];
                medico.Estado = (bool)Datos.Lector["Estado"];

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


        public void Modificar(Medico medico)
        {
            Datos = new DataAcces();
            try
            {   /*Arreglar el seteo con los nuevos tipos de datos*/
                Datos.setearConsulta("update Medicos set Nombre = @Nombre, Apellido = @Apellido, Domicilio = @Domicilio, EMail = @EMail, Contrasena = @Contrasena, Celular = @Celular, Especialidad = @Especialidad, Matricula = @Matricula where ID = @ID");

                Datos.setearParametro("@ID", medico.ID);
                Datos.setearParametro("@Apellido", medico.Apellido);
                Datos.setearParametro("@Celular", medico.Celular);
                Datos.setearParametro("@Domicilio", medico.Domicilio);
                Datos.setearParametro("@Email", medico.Email);
                Datos.setearParametro("@Especialidad", medico.Especialidad);
                Datos.setearParametro("@FechaNacimiento", medico.FechaNacimiento);
                Datos.setearParametro("@Matricula", medico.Matricula);
                Datos.setearParametro("@Nombre", medico.Nombre);

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


        public void Cargar(Medico medico)
        {
            Datos = new DataAcces();
            try
            {
                Datos.setearConsulta("insert into Medicos (ID, Nombre, Apellido, FechaNacimiento, Domicilio, EMail, Contrasena, Celular, Celular, Genero, Matricula, Especialidad, Estado) values (@ID, @Nombre, @Apellido, @FechaNacimiento, @Domicilio, @EMail, @Contrasena, @Celular, @Celular, @Genero, @Matricula, @Especialidad, @Estado)");

                Datos.setearParametro("@Apellido", medico.Apellido);
                Datos.setearParametro("@Celular", medico.Celular);
                Datos.setearParametro("@Domicilio", medico.Domicilio);
                Datos.setearParametro("@Email", medico.Email);
                Datos.setearParametro("@Especialidad", medico.Especialidad);
                Datos.setearParametro("@Estado", medico.Estado);
                Datos.setearParametro("@FechaNacimiento", medico.FechaNacimiento);
                Datos.setearParametro("@Genero", medico.Genero);
                Datos.setearParametro("@ID", medico.ID);
                Datos.setearParametro("@Matricula", medico.Matricula);
                Datos.setearParametro("@Nombre", medico.Nombre);

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

        public void Eliminar(int ID)
        {
            Datos = new DataAcces();
            try
            {
                Datos.setearConsulta("update Medicos set Estado = @Estado where ID = @ID");

                Datos.setearParametro("@ID", ID);
                Datos.setearParametro("@Estado", false);

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
