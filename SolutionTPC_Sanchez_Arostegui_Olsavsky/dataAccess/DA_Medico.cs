using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace dataAccess
{
    public class DA_Medico
    {
        public List<Medico> ListMedico { get; set; }
        public Medico medico { get; set; }

        public DataAcces AcesoDatos;

        public DA_Medico()
        {
            AcesoDatos = new DataAcces();
        }

        public bool Agregar(Medico medico)
        {
            return true;
        }

        public List<Medico> Lisar()
        {
            return ListMedico;
        }

        public Medico ListarID(int ID)
        {
            return this.medico;
        }

        public bool Eliminar()
        {
            return true;
        }

    }
}
