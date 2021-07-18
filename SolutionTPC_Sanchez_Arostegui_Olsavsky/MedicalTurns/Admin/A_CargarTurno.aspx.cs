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

        public List<DisponibilidadHoraria> DHlista = new List<DisponibilidadHoraria>();
        public N_DisponibilidadHoraria DHnegocio = new N_DisponibilidadHoraria();
        public DisponibilidadHoraria disponibilidadHorarias = new DisponibilidadHoraria();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            /*
                Otra Opcion es dejar que el usuario introduzca el horario, cada un intevalo definido y fijarse
                si estan en la BD turnos si no existe se lo asignamos y si existe no le dejamos

                Pero no puede poner horarios mayores o menores al horario de cada medico con respecto a su horario -> 
                esto se soluciona creando otro evento en DropDownList Medico .!!
             */
        }

        protected void cFecha_SelectionChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(ddlMedico.SelectedItem.Value);
            DateTime fecha = cFecha.SelectedDate;

            TimeSpan Intervalo = new TimeSpan(00, 30, 00);

            DHlista = DHnegocio.ListarIDMedicoFecha(ID, fecha);

            foreach (dominio.DisponibilidadHoraria item in DHlista)
            {
                while ((item.HoraInicio + Intervalo) == item.HoraFin)
                {
                    //falta un if o algo que haga el primero igual y al segundo le sume
                    TimeSpan tiempo = item.HoraInicio + Intervalo;

                    ListItem listItemAux = new ListItem(tiempo.ToString(), tiempo.ToString());
                    ddlHorarios.Items.Add(listItemAux);
                }
            }
        }

    }
}