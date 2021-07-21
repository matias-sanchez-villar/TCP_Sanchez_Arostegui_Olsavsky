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
    public partial class A_CargarEspecialidad : System.Web.UI.Page
    {
        public List<Especialidad> lista;

        protected void Page_Load(object sender, EventArgs e)
        {
            Modificar();

            N_Especialidad Negocio = new N_Especialidad();
            lista = Negocio.listar();

            Session.Add("Especialidad", lista);

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            N_Especialidad Negocio = new N_Especialidad();
            Especialidad especialidad = new Especialidad();

            if (!(string.IsNullOrEmpty(Request.QueryString["ID"])))
            {

                int ID = int.Parse(Request.QueryString["ID"]);

                lista = (List<Especialidad>)Session["Especialidad"];

                especialidad = lista.Find(x => x.ID == ID);

                especialidad.Nombre = Especialidad.Text;


                Negocio.Modificar(especialidad);

            }
            else
            {
                especialidad.Nombre = Especialidad.Text;

                Negocio.Cargar(especialidad);
                
            }

            Response.Redirect("A_CargarEspecialidad.aspx");
        }

        public void Modificar()
        {
            N_Especialidad Negocio = new N_Especialidad();
            Especialidad especialidad = new Especialidad();

            try
            {

                if (!(string.IsNullOrEmpty(Request.QueryString["ID"])) && Session["Especialidad"] != null)
                {
                    int ID = int.Parse(Request.QueryString["ID"]);

                    lista = (List<Especialidad>)Session["Especialidad"];

                    especialidad = lista.Find(x => x.ID == ID);

                    Especialidad.Attributes.Add("placeholder", especialidad.Nombre);
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