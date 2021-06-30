using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataAccess;

namespace negocio
{
    public class N_Paciente
    {
        public List<Paciente> Lista { get; set; }
        public DataAcces Datos { get; set; }

        public List<Paciente> Listar()
        {
            Datos = new DataAcces();
            Lista = new List<Paciente>();

            try
            {

                string Select = " select p.ID, p.Nombre, p.Apellido, p.FechaNacimiento, p.Domicilio, p.Celular, p.Genero, p.NroAfiliado, o.ObraSocial, u.Email ";
                string From = " from Pacientes p ";
                string JoinU = " inner join Usuarios u on u.ID = p.IDUsuario ";
                string JoinE = " inner join ObrasSociales o on o.ID = p.IDObraSocial ";
                string Where = " where u.Estado = 1 ";
                string query = Select + From + JoinU + JoinE + Where;

                Datos.setearConsulta(query);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Paciente paciente = new Paciente();

                    paciente.ID = (int)Datos.Lector["ID"];
                    paciente.Nombre = (string)Datos.Lector["Nombre"];
                    paciente.Apellido = (string)Datos.Lector["Apellido"];
                    paciente.FechaNacimiento = (DateTime)Datos.Lector["FechaNacimiento"];
                    paciente.Domicilio = (string)Datos.Lector["Domicilio"];
                    paciente.Celular = (string)Datos.Lector["Celular"];
                    paciente.Genero = (string)Datos.Lector["Genero"];
                    paciente.NroAfiliado = (string)Datos.Lector["NroAfiliado"];
                    paciente.ObraSocial = (string)Datos.Lector["ObraSocial"];
                    paciente.Usuario.Email = (string)Datos.Lector["Email"];

                    Lista.Add(paciente);
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

        public Paciente BuscarPacienteID(int ID)
        {
            Datos = new DataAcces();

            try
            {

                string Select = " select p.ID, p.Nombre, p.Apellido, p.FechaNacimiento, p.Domicilio, p.Celular, p.Genero, p.NroAfiliado, o.ObraSocial, u.Email ";
                string From = " from Pacientes p ";
                string JoinU = " inner join Usuarios u on u.ID = p.IDUsuario ";
                string JoinE = " inner join ObrasSociales o on o.ID = p.IDObraSocial ";
                string Where = " where u.Estado = 1 and p.ID = " + ID;
                string query = Select + From + JoinU + JoinE + Where;

                Datos.setearConsulta(query);

                Datos.ejecutarLectura();

                    Paciente paciente = new Paciente();

                    paciente.ID = (int)Datos.Lector["ID"];
                    paciente.Nombre = (string)Datos.Lector["Nombre"];
                    paciente.Apellido = (string)Datos.Lector["Apellido"];
                    paciente.FechaNacimiento = (DateTime)Datos.Lector["FechaNacimiento"];
                    paciente.Domicilio = (string)Datos.Lector["Domicilio"];
                    paciente.Celular = (string)Datos.Lector["Celular"];
                    paciente.Genero = (string)Datos.Lector["Genero"];
                    paciente.NroAfiliado = (string)Datos.Lector["NroAfiliado"];
                    paciente.ObraSocial = (string)Datos.Lector["ObraSocial"];
                    paciente.Usuario.Email = (string)Datos.Lector["Email"];

                return paciente;
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

        public void Cargar(Paciente paciente)
        {
            Datos = new DataAcces();

            N_Usuario usuario = new N_Usuario();
            try
            {

                Datos.setearConsulta(" insert into Pacientes(Nombre, Apellido, Domicilio, Celular, FechaNacimiento, Genero, NroAfiliado, IDUsuario, IDObraSocial) values (@Nombre, @Apellido, @Domicilio, @Celular, @FechaNacimiento, @Genero, @NroAfiliado, @IDUsuario, @IDObraSocial) ");

                Datos.setearParametro("@Nombre", paciente.Nombre);
                Datos.setearParametro("@Apellido", paciente.Apellido);
                Datos.setearParametro("@Domicilio", paciente.Domicilio);
                Datos.setearParametro("@Celular", paciente.Celular);
                Datos.setearParametro("@FechaNacimiento", paciente.FechaNacimiento);
                Datos.setearParametro("@Genero", paciente.Genero);
                Datos.setearParametro("@NroAfiliado", paciente.NroAfiliado);
                Datos.setearParametro("@IDUsuario", usuario.Cargar(paciente.Usuario));

                //Datos.setearParametro("@IDObraSocial", paciente.IDObraSocial); es un int de ID y carga un string/varchar

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

        //public void Modificar(Paciente paciente)
        //{
        //    Datos = new DataAcces();
        //    try
        //    {
        //        Datos.setearConsulta("update Medicos set Nombre = @Nombre, Apellido = @Apellido, Domicilio = @Domicilio, EMail = @EMail, Contrasena = @Contrasena, Celular = @Celular, ObraSocial = @ObraSocial, NroAfiliado = @NroAfiliado where ID = @ID");

        //        Datos.setearParametro("@ID", paciente.ID);
        //        Datos.setearParametro("@Apellido", paciente.Apellido);
        //        Datos.setearParametro("@Celular", paciente.Celular);
        //        Datos.setearParametro("@Domicilio", paciente.Domicilio);
        //        Datos.setearParametro("@Email", paciente.Email);
        //        Datos.setearParametro("@ObraSocial", paciente.ObraSocial);
        //        Datos.setearParametro("@FechaNacimiento", paciente.FechaNacimiento);
        //        Datos.setearParametro("@NroAfiliado", paciente.NumeroAfiliado);
        //        Datos.setearParametro("@Nombre", paciente.Nombre);

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
        //        Datos.setearConsulta("update Paciente set Estado = @Estado where ID = @ID");

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
