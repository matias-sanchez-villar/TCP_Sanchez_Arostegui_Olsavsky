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
    public partial class A_CargarMedico : System.Web.UI.Page
    {
        public List<Medico> listaMedicos;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EliminarMedico();

                ///Listamos a medico
                N_Medico medicoNegocio = new N_Medico();
                listaMedicos = medicoNegocio.Listar();

                Session.Add("Medico", listaMedicos);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //Response.Redirect("Dashboard.aspx");
            }
        }

        protected void EliminarMedico()
        {
            List<Medico> lista;
            Medico medico = new Medico();
            N_Medico negocio = new N_Medico();

            try
            {

                if (!(string.IsNullOrEmpty(Request.QueryString["IDMedico"])) && Session["Medico"] != null)
                {
                    int ID = int.Parse(Request.QueryString["IDMedico"]);

                    lista = (List<Medico>)Session["Paciente"];

                    medico = lista.Find(x => x.ID == ID);

                    negocio.Eliminar(medico);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}