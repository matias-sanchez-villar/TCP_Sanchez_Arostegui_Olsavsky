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
        public Paciente paciente = new Paciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarPaciente();
            }
        }

        public void ListarPaciente()
        {
            try
            {

                if (!(string.IsNullOrEmpty(Request.QueryString["ID"])) && Session["Paciente"] != null)
                {
                    int ID = int.Parse(Request.QueryString["ID"]);

                    lista = (List<Paciente>)Session["Paciente"];

                    paciente = lista.Find(x => x.ID == ID);

                    
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
                    Response.Redirect("A_Dashboard.aspx");
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
                throw ex;
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {

            /*COMENTO ESTO QUE ESTABA ANTES
             * Page.Validate();

            if (Page.IsValid)
            {
                N_Paciente negocio = new N_Paciente();

                paciente.Nombre = Nombre.Text;
                paciente.Apellido = Apellido.Text;
                paciente.FechaNacimiento = DateTime.Parse(Nacimiento.Text);
                paciente.Genero = Genero.SelectedValue;
                paciente.obraSocial.ID = Convert.ToInt32(ObraSocial.SelectedValue.ToString());
                paciente.Domicilio = Domicilio.Text;
                paciente.Celular = Celular.Text;
                paciente.NroAfiliado = Afiliado.Text;

                paciente.Usuario.Email = Email.Text;
                //paciente.Usuario.Contrasena = Contrasena.Text;

                negocio.Modificar(paciente);
                Response.Redirect("P_Dashboard.aspx");
            
            }*/

            Page.Validate();
            if (!Page.IsValid) return;

            else
            {
                N_Paciente negocio = new N_Paciente();
                Paciente pacAux = new Paciente();

                pacAux.ID = int.Parse(Request.QueryString["ID"]);
                pacAux.Nombre = Nombre.Text;
                pacAux.Apellido = Apellido.Text;
                pacAux.FechaNacimiento = DateTime.Parse(Nacimiento.Text);
                pacAux.Genero = Genero.SelectedValue;
                pacAux.obraSocial.ID = Convert.ToInt32(ObraSocial.SelectedValue.ToString());
                pacAux.Domicilio = Domicilio.Text;
                pacAux.Celular = Celular.Text;
                pacAux.NroAfiliado = Afiliado.Text;
                pacAux.Usuario.ID = int.Parse(Request.QueryString["IDUsuario"]);
                pacAux.Usuario.Email = Email.Text;
                pacAux.Usuario.Contrasena = "root";
                
                

                negocio.Modificar(pacAux);
                Response.Redirect("A_Dashboard.aspx");
            }

        }
    }
}