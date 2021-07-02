using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using negocio;
using dataAccess;
using dominio;

namespace negocio
{
    public class N_ObraSocial
    {
        List<ObraSocial> lista;
        DataAcces datos;

        public List<ObraSocial> listar()
        {
            datos = new DataAcces();
            lista = new List<ObraSocial>();
            
            try
            {
                datos.setearConsulta(" select ID, ObraSocial from ObrasSociales ");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ObraSocial aux = new ObraSocial();

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


        public void Modificar(ObraSocial obraSocial)
        {
            datos = new DataAcces();

            try
            {
                datos.setearConsulta(" update ObrasSociales set ObraSocial = @ObraSocial where ID = @ID  ");

                datos.setearParametro("@ID", obraSocial.ID);
                datos.setearParametro("@Nombre", obraSocial.Nombre);

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
