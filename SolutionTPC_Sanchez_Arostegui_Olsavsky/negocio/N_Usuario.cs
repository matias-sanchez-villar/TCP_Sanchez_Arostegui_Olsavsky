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

        public void Cargar(Usuario usuario)
        {
            Datos = new DataAcces();

            try
            {
                Datos.setearConsulta(" insert into Usuarios (Email, Contrasena, Estado) VALUES( @Email, @Contrasena, @Estado )");

                Datos.setearParametro("@Email", usuario.Email);
                Datos.setearParametro("@Contrasena", usuario.Contrasena);
                Datos.setearParametro("@Estado", 1);

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
            int ID = -1;

            try
            {
                Datos.setearConsulta(" select ID from Usuarios where Email = @Email ");

                Datos.setearParametro("@Email", Email);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())                   ///CHEQUEAR ESTA PRUEBA DEL WHILE 
                {
                    ID = (int)Datos.Lector["ID"];
                }

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

                Datos.setearParametro("@ID", usuario.ID);

                Datos.setearConsulta(" delete from Usuarios where ID = @ID ");

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
