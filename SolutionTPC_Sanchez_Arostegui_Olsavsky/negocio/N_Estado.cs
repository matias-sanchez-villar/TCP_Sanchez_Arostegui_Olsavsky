using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataAccess;

namespace negocio
{
    public class N_Estado
    {
        public List<Estado> Lista { get; set; }
        public DataAcces Datos { get; set; }

        public List<Estado> Listar()
        {
            Datos = new DataAcces();
            Lista = new List<Estado>();

            try
            {
                string query = (" select ID, Nombre from EstadoTurno ");

                Datos.setearConsulta(query);

                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Estado estado = new Estado();

                    estado.ID = (int)Datos.Lector["ID"];
                    estado.Nombre = (string)Datos.Lector["Nombre"];

                    Lista.Add(estado);
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

        public Estado ListarID(int ID)
        {
            Datos = new DataAcces();
            Lista = new List<Estado>();

            try
            {
                string query = (" select ID, Nombre from EstadoTurno where ID = " + ID);

                Datos.setearConsulta(query);

                Datos.ejecutarLectura();

                Datos.Lector.Read();

                    Estado estado = new Estado();

                    estado.ID = (int)Datos.Lector["ID"];
                    estado.Nombre = (string)Datos.Lector["Nombre"];

                    Lista.Add(estado);

                return estado;
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
