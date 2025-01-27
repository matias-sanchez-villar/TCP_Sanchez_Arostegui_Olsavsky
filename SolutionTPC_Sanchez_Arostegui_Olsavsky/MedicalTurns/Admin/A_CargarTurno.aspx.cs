﻿using System;
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
            UsuarioAdmi();
            // Carga los turnos en session
            Tlista = Tnegocio.Listar();
            Session.Add("Turno", Tlista);
            EliminarTurno();

            if (!IsPostBack)
            {
                
                // Lista las especialidades en el drop down list
                listarEspecialidades();

                // Lista los pacientes en el drop down list
                listarPacientes();

            }
        }

        protected void UsuarioAdmi()
        {
            if (Session["AdmiSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
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
                Response.Redirect("A_Error.aspx", false);
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

                Response.Redirect("A_Error.aspx", false);
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
            Page.Validate();
            if (!Page.IsValid) return;

            else
            {
                N_Turno NTurno = new N_Turno();
                Turno turnoAux = new Turno();
                            
                        
                turnoAux.Fecha = cFecha.SelectedDate;
                turnoAux.Hora = TimeSpan.Parse(ddlHorarios.SelectedValue);
                turnoAux.medico.ID = Convert.ToInt32(ddlMedico.SelectedValue.ToString());
                turnoAux.paciente.ID = Convert.ToInt32(ddlPaciente.SelectedValue.ToString());

                NTurno.Cargar(turnoAux);

                string EmailPaciente = NTurno.EmailPaciente(turnoAux);
                string TextoEmail = "Reservo un turno para el día: " + turnoAux.Fecha.ToString("dd/MM/yy") + " en el horario de: " + turnoAux.Hora.ToString() + " con el médico: " + ddlMedico.SelectedItem;
                N_EmailService emailService = new N_EmailService();
                emailService.armarCorreo(EmailPaciente, "Turno Agendado", TextoEmail);

                try
                {
                    emailService.enviarEmail();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("A_Error.aspx", false);

                }
            }
        }

        protected void cFecha_SelectionChanged(object sender, EventArgs e)
        {
            ddlHorarios.Items.Clear();
            ListItem listItem = new ListItem("Horarios", "Horarios ");
            ddlHorarios.Items.Add(listItem);

            int ID = int.Parse(ddlMedico.SelectedItem.Value);
            DateTime fecha = cFecha.SelectedDate;
            DateTime thisDay = DateTime.Now;

            if (fecha > thisDay)
            {

                TimeSpan Intervalo = new TimeSpan(01, 00, 00);

                DHlista = DHnegocio.ListarIDMedicoFecha(ID, fecha);

                Tlista = Tnegocio.ListarIDMedicoFecha(ID, fecha);


                foreach (dominio.DisponibilidadHoraria item in DHlista)
                {
                    while ((item.HoraInicio + Intervalo) <= item.HoraFin)
                    {
                        TimeSpan tiempo = item.HoraInicio;

                        if (!Tlista.Exists(x => x.Hora == tiempo))
                        {
                            ListItem listItemAux = new ListItem(tiempo.ToString(), tiempo.ToString());
                            ddlHorarios.Items.Add(listItemAux);
                        }

                        item.HoraInicio = item.HoraInicio + Intervalo;
                    }
                }
            }
        }

        protected void EliminarTurno()
        {
            try
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["IDTurno"])))
                {
                    N_Turno negocio = new N_Turno();


                    negocio.Eliminar(Convert.ToInt32(Request.QueryString["IDTurno"]));
                    Response.Redirect("A_CargarTurno.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("A_Error.aspx", false);
            }
        }

    }
}