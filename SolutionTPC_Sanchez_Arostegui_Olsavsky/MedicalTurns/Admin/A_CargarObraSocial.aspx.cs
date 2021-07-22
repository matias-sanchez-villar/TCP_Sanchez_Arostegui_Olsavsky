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
            UsuarioAdmi();
            Modificar();

            N_ObraSocial Negocio = new N_ObraSocial();
            
            lista = Negocio.listar();

            Session.Add("ObraSocial", lista);
        }

        protected void UsuarioAdmi()
        {
            if (Session["AdmiSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            N_ObraSocial Negocio = new N_ObraSocial();
            ObraSocial obraSocial = new ObraSocial();

            if (!(string.IsNullOrEmpty(Request.QueryString["ID"])))
            {

                int ID = int.Parse(Request.QueryString["ID"]);

                lista = (List<ObraSocial>)Session["ObraSocial"];

                obraSocial = lista.Find(x => x.ID == ID);

                obraSocial.Nombre = ObraSocial.Text;

                Negocio.Modificar(obraSocial);

                Response.Redirect("A_CargarObraSocial.aspx", false);
            }
            else
            {

                    obraSocial.Nombre = ObraSocial.Text;
                    Negocio.Cargar(obraSocial);
                    Response.Redirect("A_CargarObraSocial.aspx", false);

            }
        }

        public void Modificar()
        {
            ObraSocial obrasocial = new ObraSocial();
            N_ObraSocial negocio = new N_ObraSocial();

            try
            {

                if (!(string.IsNullOrEmpty(Request.QueryString["ID"])) && Session["ObraSocial"] != null)
                {
                    int ID = int.Parse(Request.QueryString["ID"]);

                    lista = (List<ObraSocial>)Session["ObraSocial"];

                    obrasocial = lista.Find(x => x.ID == ID);

                    ObraSocial.Attributes.Add("placeholder", obrasocial.Nombre);


                    btnAgregar.Text = "Modificar";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}