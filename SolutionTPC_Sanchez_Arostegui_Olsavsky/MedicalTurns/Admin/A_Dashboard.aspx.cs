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

        public Medico medico = new Medico();
        public Paciente paciente = new Paciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ElimarMedico();
                EliminarPaciente();

                ///Listamos a medico
                N_Medico medicoNegocio = new N_Medico();
                listaMedicos = medicoNegocio.Listar();

                Session.Add("Medico", listaMedicos);


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

        protected void ElimarMedico()
        {
            try
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["IDMedico"])) && Session["Medico"] != null)
                {
                    N_Medico negocio = new N_Medico();

                    medico = RetornarMedico();

                    negocio.Eliminar(medico);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void EliminarPaciente()
        {
            try
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["IDPaciente"])) && Session["Paciente"] != null)
                {
                    N_Paciente negocio = new N_Paciente();

                    paciente = RetornarPaciente();

                    negocio.Eliminar(paciente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected Medico RetornarMedico()
        {
            int ID = int.Parse(Request.QueryString["IDMedico"]);

            listaMedicos = (List<Medico>)Session["Medico"];

            medico = new Medico();

            return medico = listaMedicos.Find(x => x.ID == ID);
        }

        protected Paciente RetornarPaciente()
        {
            int ID = int.Parse(Request.QueryString["IDPaciente"]);

            listaPaciente = (List<Paciente>)Session["Paciente"];

            paciente = new Paciente();

            return paciente = listaPaciente.Find(x => x.ID == ID);
        }

    }   
}

