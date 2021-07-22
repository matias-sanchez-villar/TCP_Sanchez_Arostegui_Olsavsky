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
    public partial class Dashboard : System.Web.UI.Page
    {
        public List<Paciente> listaPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionPaciente();
            try
            {
                ///Listamos Paciente
                N_Paciente paciente = new N_Paciente();
                listaPaciente = paciente.Listar();

                Session.Add("Paciente", listaPaciente);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //Response.Redirect("Dashboard.aspx");
            }
        }

        protected void SessionPaciente()
        {
            if (Session["PacienteSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
            }
        }

    }
}