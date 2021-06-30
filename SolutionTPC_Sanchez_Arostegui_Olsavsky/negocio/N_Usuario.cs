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
                Datos.setearConsulta(" insert into Usuarios (Email, Contasena, Estado) VALUES ");

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
            Datos = new DataAcces();
            int ID;

            try
            {
                Datos.setearConsulta(" select ID from Usuarios where Email = " + Email);
                Datos.ejecutarLectura();

                return ID = (int)Datos.Lector["ID"];

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
