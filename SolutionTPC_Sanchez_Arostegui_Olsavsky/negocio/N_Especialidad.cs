using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataAccess;


namespace negocio
{
    public class N_Especialidad
    {
        List<Especialidad> lista;
        DataAcces datos;

        public List<Especialidad> listar()
        {
            datos = new DataAcces();
            lista = new List<Especialidad>();

            try
            {
                datos.setearConsulta(" select ID, Especialidad from Especialidades ");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["ObraSocial"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Especialidad especialidad)
        {
            datos = new DataAcces();

            try
            {
                datos.setearConsulta(" update Especialidades set Especialidad = @Especialidad where ID = @ID  ");

                datos.setearParametro("@ID", especialidad.ID);
                datos.setearParametro("@Nombre", especialidad.Nombre);

                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }
        }
    }
}
