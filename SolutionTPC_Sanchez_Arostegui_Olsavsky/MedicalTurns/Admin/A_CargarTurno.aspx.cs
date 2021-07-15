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

        public List<Paciente> Plista = new List<Paciente>();
        public N_Paciente Pnegocio = new N_Paciente();
        public Paciente paciente = new Paciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // Eliminar Turno
                EliminarTurno();

                // Carga los turnos en session
                Tlista = Tnegocio.Listar();
                Session.Add("Turno", Tlista);

                // Lista las especialidades en el drop down list
                listarEspecialidades();

                // Lista los pacientes en el drop down list
                listarPacientes();

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

        public void listarPacientes()
        {
            try
            {
                Plista = Pnegocio.Listar();

                foreach (dominio.Paciente item in Plista)
                {
                    string nombreAux = item.Nombre.ToString();
                    string apellidoAux = item.Apellido.ToString();
                    string completeName = nombreAux + " " + apellidoAux;
                    string IDpaciente = item.ID.ToString();

                    ListItem listItemAux = new ListItem(completeName, IDpaciente);
                    ddlPaciente.Items.Add(listItemAux);
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

            ddlMedico.Items.Clear();

            foreach (dominio.Medico item in Mlista)
            {

                string nombreAux = item.Nombre.ToString();
                string apellidoAux = item.Apellido.ToString();
                string completeName = nombreAux + " " + apellidoAux;
                string IDpaciente = item.ID.ToString();

                ListItem listItemAux = new ListItem(completeName, IDpaciente);
                ddlMedico.Items.Add(listItemAux);

            }
        }

        public void EliminarTurno()
        {
            try
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["ID"])) && Session["Turno"] != null)
                {
                    Tnegocio = new N_Turno();

                    turno = retornarTurno();

                    Tnegocio.Eliminar(turno);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Turno retornarTurno()
        {
            int ID = int.Parse(Request.QueryString["ID"]);

            Tlista = new List<Turno>();

            Tlista = (List<Turno>)Session["Turno"];

            turno = new Turno();

            return turno = Tlista.Find(x => x.ID == ID);
        }

    }
}