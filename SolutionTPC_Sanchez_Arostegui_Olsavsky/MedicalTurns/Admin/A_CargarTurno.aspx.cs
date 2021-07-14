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
    public partial class A_CargarTurno1 : System.Web.UI.Page
    {
        public List<Turno> Tlista = new List<Turno>();
        public N_Turno Tnegocio = new N_Turno();
        public Turno turno = new Turno();

        public List<Medico> Mlista = new List<Medico>();
        public N_Medico Mnegocio = new N_Medico();
        public Medico medico = new Medico();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tlista = Tnegocio.Listar();

                listarEspecialidades();

                Session.Add("Turno", Tlista);
            }
        }

        public void listarEspecialidades()
        {
            try
            {

                List<Especialidad> listaEspecialidades = new List<Especialidad>();
                N_Especialidad aux = new N_Especialidad();
                listaEspecialidades = aux.listar();

                foreach (dominio.Especialidad item in listaEspecialidades)
                {
                    string nombreAux = item.Nombre.ToString();
                    string valueAux = item.ID.ToString();
                    ListItem listItemAux = new ListItem(nombreAux, valueAux);
                    ddlEspecialidad.Items.Add(listItemAux);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(ddlEspecialidad.SelectedItem.Value);

            Mlista = Mnegocio.ListarEspecialidad(ID);

            foreach (dominio.Medico item in Mlista)
            {

                ddlMedico.DataSource = Mlista;
                ddlMedico.DataTextField = "Nombre";
                ddlMedico.DataValueField = "ID";
                ddlMedico.DataBind();

            }
        }
    }
}