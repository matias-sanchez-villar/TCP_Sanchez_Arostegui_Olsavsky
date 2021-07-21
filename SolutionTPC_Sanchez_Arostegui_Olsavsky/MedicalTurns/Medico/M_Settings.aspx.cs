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
            Medico medAux = new Medico();

            medAux = (Medico)Session["MedicoSettings"];

            Email.Text = medAux.Usuario.Email;
        }
    }
}