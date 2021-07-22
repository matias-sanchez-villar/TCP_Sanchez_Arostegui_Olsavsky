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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Medico> listaMedicos;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionMedico();
            try
            {
                ///Listamos a medico
                N_Medico medicoNegocio = new N_Medico();
                listaMedicos = medicoNegocio.Listar();

                Session.Add("Medicos", listaMedicos);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //Response.Redirect("Dashboard.aspx");
            }

        }

        protected void SessionMedico()
        {
            if (Session["MedicoSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
            }
        }
    }
}