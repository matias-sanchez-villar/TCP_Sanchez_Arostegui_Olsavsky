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
                Datos.setearConsulta(" insert into Usuarios (Email, Contasena, Estado) VALUES( @Email, @Contasena, @Estado )");

                Datos.setearParametro("@Email", usuario.Email);
                Datos.setearParametro("@Contasena", usuario.Contrasena);
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
            int ID;

            try
            {
                Datos.setearConsulta(" select ID from Usuarios where Email = @Email ");

                Datos.setearParametro("@Email", Email);

                Datos.ejecutarLectura();

                ID = (int)Datos.Lector["ID"];
                
                Datos.cerrarConexion();
                return ID ;

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
                Datos.setearConsulta(" update Usuarios set Email = @Email, Contasena = @Contasena, Estado = @Estado where ID = @ID )");

                Datos.setearParametro("@ID", usuario.ID);
                Datos.setearParametro("@Email", usuario.Email);
                Datos.setearParametro("@Contasena", usuario.Contrasena);
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

    }
}
