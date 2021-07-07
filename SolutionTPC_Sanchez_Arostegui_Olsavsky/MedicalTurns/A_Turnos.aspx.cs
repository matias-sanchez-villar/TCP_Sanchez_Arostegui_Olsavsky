using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace MedicalTurns
{
    public partial class A_Turnos : System.Web.UI.Page
    {
        public List<Turno> lista;

        protected void Page_Load(object sender, EventArgs e)
        {
            N_Turno Negocio = new N_Turno();

            lista = Negocio.Listar();

            Session.Add("Turno", lista);
        }
    }
}