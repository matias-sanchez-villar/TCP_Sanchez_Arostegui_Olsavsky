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
    public partial class A_CargarObraSocial : System.Web.UI.Page
    {
        public List<ObraSocial> lista;

        protected void Page_Load(object sender, EventArgs e)
        {
            N_ObraSocial Negocio = new N_ObraSocial();
            
            lista = Negocio.listar();

            Session.Add("ObraSocial", lista);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) return;

            else
            {
                N_ObraSocial Negocio = new N_ObraSocial();
                ObraSocial obraSocial = new ObraSocial();

                obraSocial.Nombre = ObraSocial.Text;

                Negocio.Cargar(obraSocial);
                Response.Redirect("A_CargarObraSocial.aspx");
            }
        }
    }
}