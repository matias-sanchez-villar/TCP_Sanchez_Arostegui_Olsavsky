using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataAccess;

namespace negocio
{
    public class N_Usuario
    {
        public DataAcces Datos;

        public List<Usuario> listar()
        {
            List<Usuario> userList = new List<Usuario>();
            Datos = new DataAcces();

            try
            {
                string query = " SELECT U.ID, U.Email, U.Contrasena, U.TipoUsuario FROM Usuarios U ";

                Datos.setearConsulta(query);
                Datos.ejecutarLectura();

                while(Datos.Lector.Read())
                {
                    Usuario user = new Usuario();

                    user.ID = (int)Datos.Lector["ID"];
                    user.Email = (string)Datos.Lector["Email"];
                    user.Contrasena = (string)Datos.Lector["Contrasena"];
                    user.tipoUsuario = (int)Datos.Lector["TipoUsuario"];
                    user.Estado = false;

                    userList.Add(user);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }

            return userList;
        }

        public void Cargar(Usuario usuario)
        {
            Datos = new DataAcces();

            try
            {
                Datos.setearConsulta(" insert into Usuarios (Email, Contrasena, Estado, TipoUsuario) VALUES( @Email, @Contrasena, @Estado, @TipoUsuario )");

                Datos.setearParametro("@Email", usuario.Email);
                Datos.setearParametro("@Contrasena", usuario.Contrasena);
                Datos.setearParametro("@Estado", 1);
                Datos.setearParametro("@TipoUsuario", usuario.tipoUsuario);

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

        public int RetornarID(string Email)
        {
            Datos = new DataAcces();
            try
            {
                Datos.setearConsulta(" select ID from Usuarios where Email = @Email ");

                Datos.setearParametro("@Email", Email);

                Datos.ejecutarLectura();

                Datos.Lector.Read();

                int ID = (int)Datos.Lector["ID"];

                Datos.cerrarConexion();

                return ID;

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

        public void Modificar(Usuario usuario)
        {
            Datos = new DataAcces();

            try
            {
                Datos.setearConsulta(" update Usuarios set Email = @Email, Contrasena = @Contrasena, Estado = @Estado where ID = @ID ");

                Datos.setearParametro("@ID", usuario.ID);
                Datos.setearParametro("@Email", usuario.Email);
                Datos.setearParametro("@Contrasena", usuario.Contrasena);
                Datos.setearParametro("@Estado", usuario.Estado);

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

        public void Eliminar(Usuario usuario)
        {
            Datos = new DataAcces();

            try
            {
                Datos.setearConsulta(" delete from Usuarios where ID = @ID ");

                Datos.setearParametro("@ID", usuario.ID);

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
