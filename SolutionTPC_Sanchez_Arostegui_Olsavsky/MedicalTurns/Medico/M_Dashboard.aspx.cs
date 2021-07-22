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
        public List<Turno> Tlista = new List<Turno>();
        public N_Turno Tnegocio = new N_Turno();
        public Turno turno = new Turno();

        public List<Medico> Mlista = new List<Medico>();
        public N_Medico Mnegocio = new N_Medico();
        public Medico medico = new Medico();

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionMedico();

            Medico pacAux = new Medico();

            medico = (Medico)Session["MedicoSettings"];

            Tlista = Tnegocio.ListarIDMedico(medico.ID);

            EliminarTurno();
        }

        protected void SessionMedico()
        {
            if (Session["MedicoSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
            }
        }

        protected void EliminarTurno()
        {
            try
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["IDTurno"])))
                {
                    N_Turno negocio = new N_Turno();


                    negocio.Eliminar(Convert.ToInt32(Request.QueryString["IDTurno"]));
                    Response.Redirect("M_Dashboard.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("M_Error.aspx", false);
            }
        }
    }
}