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
        public List<Especialidad> listaEspecialidad;

        public Medico medico = new Medico();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ElimarMedico();
                listarEspecialidad();

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

        protected void listarEspecialidad()
        {
            N_Especialidad especialidad = new N_Especialidad();
            listaEspecialidad = especialidad.listar();

            foreach (dominio.Especialidad item in listaEspecialidad)
            {
                string nombreAux = item.Nombre.ToString();
                string valueAux = item.ID.ToString();
                ListItem listItemAux = new ListItem(nombreAux, valueAux);
                Especialidad.Items.Add(listItemAux);
            }
        }

        protected Medico RetornarMedico()
        {
            int ID = int.Parse(Request.QueryString["IDMedico"]);

            listaMedicos = (List<Medico>)Session["Medico"];

            medico = new Medico();

            return medico = listaMedicos.Find(x => x.ID == ID);
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) return;

            else
            {
                N_Medico negocio = new N_Medico();

                medico.Nombre = Nombre.Text;
                medico.Apellido = Apellido.Text;
                medico.FechaNacimiento = DateTime.Parse(Nacimiento.Text);
                medico.Genero = Genero.SelectedValue;
                medico.especialidad.ID = Convert.ToInt32(Especialidad.SelectedValue.ToString());
                medico.Domicilio = Domicilio.Text;
                medico.Celular = Celular.Text;
                medico.Matricula = Matricula.Text;

                medico.Usuario.Email = Email.Text;
                medico.Usuario.Contrasena = "root";

                negocio.Cargar(medico);
                Response.Redirect("A_Dashboard.aspx");
            }
        }
    }
}