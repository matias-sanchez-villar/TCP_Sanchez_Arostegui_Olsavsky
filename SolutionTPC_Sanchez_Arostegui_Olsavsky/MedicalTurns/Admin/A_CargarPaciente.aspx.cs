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
    public partial class A_CargarPaciente : System.Web.UI.Page
    {
        public List<ObraSocial> listaObrasSociales;
        public List<Paciente> listaPaciente;

        public Paciente paciente = new Paciente();


        protected void Page_Load(object sender, EventArgs e)
        {
            EliminarPaciente();
            listarObrasSociales();

            N_Paciente paciente = new N_Paciente();
            listaPaciente = paciente.Listar();

            Session.Add("Paciente", listaPaciente);

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

                    Response.Redirect("A_CargarPaciente.aspx");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected Paciente RetornarPaciente()
        {
            int ID = int.Parse(Request.QueryString["IDPaciente"]);

            listaPaciente = (List<Paciente>)Session["Paciente"];

            return paciente = listaPaciente.Find(x => x.ID == ID);
        }

        protected void listarObrasSociales()
        {
            N_ObraSocial aux = new N_ObraSocial();
            listaObrasSociales = aux.listar();

            foreach (dominio.ObraSocial item in listaObrasSociales)
            {
                string nombreAux = item.Nombre.ToString();
                string valueAux = item.ID.ToString();
                ListItem listItemAux = new ListItem(nombreAux, valueAux);
                ObraSocial.Items.Add(listItemAux);
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) return;

            else
            {
                N_Paciente negocio = new N_Paciente();
                Paciente pacAux = new Paciente();

                pacAux.Nombre = Nombre.Text;
                pacAux.Apellido = Apellido.Text;
                pacAux.FechaNacimiento = DateTime.Parse(Nacimiento.Text);
                pacAux.Genero = Genero.SelectedValue;
                pacAux.obraSocial.ID = Convert.ToInt32(ObraSocial.SelectedValue.ToString());
                pacAux.Domicilio = Domicilio.Text;
                pacAux.Celular = Celular.Text;
                pacAux.NroAfiliado = Afiliado.Text;

                pacAux.Usuario.Email = Email.Text;
                pacAux.Usuario.Contrasena = "root";

                negocio.Cargar(pacAux);
                Response.Redirect("A_CargarPaciente.aspx");
            }            
        }

    }
}