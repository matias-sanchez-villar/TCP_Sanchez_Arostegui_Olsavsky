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
    public partial class WebForm2 : System.Web.UI.Page
    {

        public List<Medico> listaMedicos;
        public List<Paciente> listaPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ///Listamos a medico
                N_Medico medicoNegocio = new N_Medico();
                listaMedicos = medicoNegocio.Listar();

                Session.Add("Medico", listaMedicos);


                ///Listamos Paciente
                N_Paciente paciente = new N_Paciente();
                listaPaciente = paciente.Listar();

                Session.Add("Paciente", listaPaciente);

                if (bool.Parse(Request.QueryString["eliminarMedico"]) == true) EliminarMedico();

                if (bool.Parse(Request.QueryString["eliminarPaciente"]) == true) EliminarPaciente();

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

                    negocio.eliminar(medico);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void EliminarPaciente()
        {
            List<Paciente> lista;
            Paciente paciente = new Paciente();
            N_Paciente negocio = new N_Paciente();

            try
            {

                if (!(string.IsNullOrEmpty(Request.QueryString["IDPaciente"])) && Session["Paciente"] != null)
                {
                    int ID = int.Parse(Request.QueryString["IDPaciente"]);

                    lista = (List<Paciente>)Session["Paciente"];

                    paciente = lista.Find(x => x.ID == ID);

                    negocio.eliminar(paciente);
                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}