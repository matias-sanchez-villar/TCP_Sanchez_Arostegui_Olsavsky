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
    public partial class M_Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionMedico();

            Medico medAux = new Medico();

            medAux = (Medico)Session["MedicoSettings"];

            Email.Text = medAux.Usuario.Email;
        }

        protected void SessionMedico()
        {
            if (Session["MedicoSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Medico medAux = new Medico();
            N_Medico negocio = new N_Medico();

            medAux = (Medico)Session["MedicoSettings"];

            medAux.Usuario.Email = Email.Text;
            medAux.Usuario.Contrasena = nuevaContrasena.Text;

            negocio.Modificar(medAux);

            Response.Redirect("M_Dashboard.aspx", false);
        }
    }
}