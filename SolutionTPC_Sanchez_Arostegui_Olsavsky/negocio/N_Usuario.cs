using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataAccess;

namespace negocio
{
    class N_Usuario
    {
        public DataAcces Datos = new DataAcces();

        public int Cargar(Usuario usuario)
        {
            Datos = new DataAcces();

            try
            {
                Datos.setearConsulta(" insert into Usuarios (Email, Contasena, Estado) VALUES(@Email, @Contasena, @Estado)");

                Datos.setearParametro("@Email", usuario.Email);
                Datos.setearParametro("@Contasena", usuario.Contrasena);
                Datos.setearParametro("@Estado", 1);

                Datos.EjecutarAccion();

                return this.RetornarID(usuario.Email);
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
            DataAcces Datos2 = new DataAcces();
            int ID;

            try
            {
                Datos2.setearConsulta(" select ID from Usuarios where Email = '" + Email + "' ");
                Datos2.ejecutarLectura();

                ID = (int)Datos2.Lector["ID"];
                
                Datos2.cerrarConexion();// <<<<<<<<<<<<<---------------------acaa esta ahora el problema hago el push y seguilo de aca
                return ID ;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos2.cerrarConexion();
            }
        }

    }
}
