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
    public partial class P_settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionPaciente();

            Paciente pacAux = new Paciente();

            pacAux = (Paciente)Session["PacienteSettings"];

            Email.Text = pacAux.Usuario.Email;
        }

        protected void SessionPaciente()
        {
            if (Session["PacienteSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Paciente pacAux = new Paciente();
            N_Paciente negocio = new N_Paciente();

            pacAux = (Paciente)Session["PacienteSettings"];

            pacAux.Usuario.Email = Email.Text;
            pacAux.Usuario.Contrasena = nuevaContrasena.Text;

            negocio.Modificar(pacAux);

            Response.Redirect("P_Dashboard.aspx", false);
        }
    }
}