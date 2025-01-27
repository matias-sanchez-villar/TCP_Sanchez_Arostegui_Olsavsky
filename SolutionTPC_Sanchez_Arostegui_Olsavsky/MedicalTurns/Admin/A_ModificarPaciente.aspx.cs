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
    public partial class A_ModificarPaciente : System.Web.UI.Page
    {

        public List<Paciente> lista;
        public Paciente paciente { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioAdmi();
            if (!IsPostBack)
            {
                ListarPaciente();
            }
        }

        protected void UsuarioAdmi()
        {
            if (Session["AdmiSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
            }
        }

        public void ListarPaciente()
        {
            try
            {

                if (!(string.IsNullOrEmpty(Request.QueryString["ID"])) && Session["Paciente"] != null)
                {
                    paciente = RetornarPaciente();

                    Nombre.Text = paciente.Nombre;
                    Apellido.Text = paciente.Apellido;
                    Nacimiento.Text = String.Format("{0:yyyy-MM-dd}", paciente.FechaNacimiento);
                    Email.Text = paciente.Usuario.Email;
                    Domicilio.Text = paciente.Domicilio;
                    Celular.Text = paciente.Celular;
                    Afiliado.Text = paciente.NroAfiliado;

                    listarObrasSociales();
                }
                else
                {
                    Response.Redirect("A_Error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void listarObrasSociales()
        {
            try
            {

                List<ObraSocial> listaObrasSociales = new List<ObraSocial>();
                N_ObraSocial aux = new N_ObraSocial();
                listaObrasSociales = aux.listar();

                ListItem listItem = new ListItem(paciente.obraSocial.Nombre, paciente.obraSocial.ID.ToString());
                ObraSocial.Items.Add(listItem);

                foreach (dominio.ObraSocial item in listaObrasSociales)
                {
                    if (item.ID == paciente.obraSocial.ID)
                    {
                        continue;
                    }
                    string nombreAux = item.Nombre.ToString();
                    string valueAux = item.ID.ToString();
                    ListItem listItemAux = new ListItem(nombreAux, valueAux);
                    ObraSocial.Items.Add(listItemAux);
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("A_Error.aspx", false);
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) return;

            else
            {
                N_Paciente negocio = new N_Paciente();

                paciente = RetornarPaciente();
                
                paciente.Nombre = Nombre.Text;
                paciente.Apellido = Apellido.Text;
                paciente.FechaNacimiento = DateTime.Parse(Nacimiento.Text);
                paciente.Genero = Genero.SelectedValue;
                paciente.obraSocial.ID = Convert.ToInt32(ObraSocial.SelectedValue.ToString());
                paciente.Domicilio = Domicilio.Text;
                paciente.Celular = Celular.Text;
                paciente.NroAfiliado = Afiliado.Text;
                paciente.Usuario.Email = Email.Text;

                if (Contrasena.Text == null)
                {
                    paciente.Usuario.Contrasena = Contrasena.Text;
                }

                negocio.Modificar(paciente);
                Response.Redirect("A_Dashboard.aspx", false);
            }

        }

        protected Paciente RetornarPaciente()
        {
            int ID = int.Parse(Request.QueryString["ID"]);

            lista = (List<Paciente>)Session["Paciente"];

            paciente = new Paciente();

           return paciente = lista.Find(x => x.ID == ID);
        }
    }
}