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
    public partial class A_ListarMedico : System.Web.UI.Page
    {
        public List<Medico> lista;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                N_Medico medico = new N_Medico();
                lista = medico.Listar();

                Session.Add("Medico", lista);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //Response.Redirect("Dashboard.aspx");
            }

        }
    }
}