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
    public partial class P_Modificar : System.Web.UI.Page
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

        public List<DisponibilidadHoraria> DHlista = new List<DisponibilidadHoraria>();
        public N_DisponibilidadHoraria DHnegocio = new N_DisponibilidadHoraria();
        public DisponibilidadHoraria disponibilidadHorarias = new DisponibilidadHoraria();

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionPaciente();

            if (!(string.IsNullOrEmpty(Request.QueryString["ID"])))
            {
                CargarDatos();
            }
            else
            {
                Response.Redirect("P_Dashboard.aspx", false);
            }

        }

        protected void CargarDatos()
        {

            turno = Tnegocio.ListarID(int.Parse(Request.QueryString["ID"]));

            lblEspecialidad.Text = "Especialidad: " + turno.medico.especialidad.Nombre;
            lblMedico.Text = "Medico: " + turno.medico.Nombre;
            lblPaciente.Text = "Paciente: " + turno.paciente.Nombre;

        }

        protected void SessionPaciente()
        {
            if (Session["PacienteSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
            }
        }

        protected void cFecha_SelectionChanged(object sender, EventArgs e)
        {
            ddlHorarios.Items.Clear();
            ListItem listItemAuxxx = new ListItem("Horario", "Horario");
            ddlHorarios.Items.Add(listItemAuxxx);

            turno = Tnegocio.ListarID(int.Parse(Request.QueryString["ID"]));

            DateTime fecha = cFecha.SelectedDate;
            DateTime thisDay = DateTime.Now;

            if (fecha > thisDay)
            {

                TimeSpan Intervalo = new TimeSpan(01, 00, 00);

                DHlista = DHnegocio.ListarIDMedicoFecha(turno.medico.ID, fecha);

                Tlista = Tnegocio.ListarIDMedicoFecha(turno.medico.ID, fecha);


                foreach (dominio.DisponibilidadHoraria item in DHlista)
                {
                    while ((item.HoraInicio + Intervalo) <= item.HoraFin)
                    {
                        TimeSpan tiempo = item.HoraInicio;

                        if (!(Tlista.Exists(x => x.Hora == tiempo)))
                        {
                            ListItem listItemAux = new ListItem(tiempo.ToString(), tiempo.ToString());
                            ddlHorarios.Items.Add(listItemAux);
                        }

                        item.HoraInicio = item.HoraInicio + Intervalo;
                    }
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            turno = Tnegocio.ListarID(int.Parse(Request.QueryString["ID"]));

            turno.Fecha = cFecha.SelectedDate;
            turno.Hora = TimeSpan.Parse(ddlHorarios.SelectedValue);
            turno.Estado = ddlEstado.SelectedValue.ToString();

            Tnegocio.Modificar(turno);

            Response.Redirect("P_Dashboard.aspx", false);
        }
    }
}