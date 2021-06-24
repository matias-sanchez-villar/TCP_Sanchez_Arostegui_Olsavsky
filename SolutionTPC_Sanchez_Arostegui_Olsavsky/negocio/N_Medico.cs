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
        public Medico medico { get; set; }
        public List<Medico> Lista { get; set; }
        public DataAcces Datos { get; set; }

        public List<Medico> Listar()
        {
            Datos = new DataAcces();
            Lista = new List<Medico>();

            try
            {

                Datos.setearConsulta("select ID, Nombre, Apellido, FechaNacimiento, Domicilio, EMail, Contrasena, Celular, Genero, Matricula, Especialidad, Estado from Medicos");

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    medico = new Medico();

                    medico.ID = (int)Datos.Lector["ID"];
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

        public Medico GetMedico(int ID)
        {
            Datos = new DataAcces();

            try
            {

                Datos.setearConsulta("select ID, Nombre, Apellido, FechaNacimiento, Domicilio, EMail, Contrasena, Celular, Genero, Matricula, Especialidad, Estado from Medicos where ID = " + ID);

                Datos.ejecutarLectura();
                
                medico = new Medico();

                    medico.ID = (int)Datos.Lector["ID"];
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
            {
                Datos.setearConsulta("update Medicos set Nombre = @Nombre, Apellido = @Apellido, Domicilio = @Domicilio, EMail = @EMail, Contrasena = @Contrasena, Celular = @Celular, Especialidad = @Especialidad, Matricula = @Matricula where ID = @ID");

                Datos.setearParametro("@ID", medico.ID);
                Datos.setearParametro("@Apellido", medico.Apellido);
                Datos.setearParametro("@Celular", medico.Celular);
                Datos.setearParametro("@Constrasena", medico.Constrasena);
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
                Datos.setearParametro("@Constrasena", medico.Constrasena);
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
