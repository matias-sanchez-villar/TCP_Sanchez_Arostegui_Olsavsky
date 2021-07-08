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
    public partial class A_CargarTurno1 : System.Web.UI.Page
    {
        public List<Turno> lista = new List<Turno>();
        public N_Turno negocio = new N_Turno();
        public Turno turno = new Turno();

        protected void Page_Load(object sender, EventArgs e)
        {
            lista = negocio.Listar();

            Session.Add("Turno", lista);
        }
    }
}