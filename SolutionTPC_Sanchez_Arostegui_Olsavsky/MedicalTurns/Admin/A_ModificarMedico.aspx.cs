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
    public partial class A_ModificarMedico : System.Web.UI.Page
    {

        public List<Medico> lista;
        public Medico medico = new Medico();

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioAdmi();
            if (!IsPostBack)
            {
                ListarMedico();
            }
        }

        protected void UsuarioAdmi()
        {
            if (Session["AdmiSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
            }
        }

        public void ListarMedico()
        {
            try
            {

                if (!(string.IsNullOrEmpty(Request.QueryString["ID"])) && Session["Medico"] != null)
                {
                    medico = RetornarMedico();

                    Nombre.Text = medico.Nombre;
                    Apellido.Text = medico.Apellido;
                    Nacimiento.Text = String.Format("{0:yyyy-MM-dd}", medico.FechaNacimiento);
                    Email.Text = medico.Usuario.Email;
                    Domicilio.Text = medico.Domicilio;
                    Celular.Text = medico.Celular;
                    Matricula.Text = medico.Matricula;

                    listarEspecialidades();
                }
                else
                {
                    Response.Redirect("A_Dashboard.aspx", false);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void listarEspecialidades()
        {
            try
            {

                List<Especialidad> listaEspecialidades = new List<Especialidad>();
                N_Especialidad aux = new N_Especialidad();
                listaEspecialidades = aux.listar();

                ListItem listItem = new ListItem(medico.especialidad.Nombre, medico.especialidad.ID.ToString());
                Especialidad.Items.Add(listItem);

                foreach (dominio.Especialidad item in listaEspecialidades)
                {
                    if (item.ID == medico.especialidad.ID)
                    {
                        continue;
                    }
                    string nombreAux = item.Nombre.ToString();
                    string valueAux = item.ID.ToString();
                    ListItem listItemAux = new ListItem(nombreAux, valueAux);
                    Especialidad.Items.Add(listItemAux);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnModificar_Click1(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                N_Medico negocio = new N_Medico();

                medico = RetornarMedico();

                medico.Nombre = Nombre.Text;
                medico.Apellido = Apellido.Text;
                medico.FechaNacimiento = DateTime.Parse(Nacimiento.Text);
                medico.Genero = Genero.SelectedValue;
                medico.especialidad.ID = Convert.ToInt32(Especialidad.SelectedValue.ToString());
                medico.Domicilio = Domicilio.Text;
                medico.Celular = Celular.Text;
                medico.Matricula = Matricula.Text;
                medico.Usuario.Email = Email.Text;

                if (Contrasena.Text == null)
                {
                    medico.Usuario.Contrasena = Contrasena.Text;
                }

                negocio.Modificar(medico);
                Response.Redirect("A_Dashboard.aspx", false);
            }
        }

        protected Medico RetornarMedico()
        {
            int ID = int.Parse(Request.QueryString["ID"]);

            lista = (List<Medico>)Session["Medico"];

            medico = new Medico();

            return medico = lista.Find(x => x.ID == ID);
        }

    }
}