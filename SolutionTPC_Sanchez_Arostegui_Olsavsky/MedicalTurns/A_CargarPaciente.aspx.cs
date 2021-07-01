using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Dominio;
using negocio;

namespace MedicalTurns
{
    public partial class A_CargarPaciente : System.Web.UI.Page
    {
        public List<ObraSocial> listaObrasSociales;

        protected void Page_Load(object sender, EventArgs e)
        {
            N_ObraSocial aux = new N_ObraSocial();
            listaObrasSociales = aux.listar();

            foreach (Dominio.ObraSocial item in listaObrasSociales)
            {   
                // Solucion inicial
                //ObraSocial.Items.Add(item.Nombre);
                //ObraSocial.Items.Add(item.ID.ToString());

                // Revisar que se manden bien los values
                string nombreAux = item.Nombre.ToString();
                string valueAux = item.ID.ToString();
                ListItem listItemAux = new ListItem(nombreAux, valueAux);
                ObraSocial.Items.Add(listItemAux);
                
                // Para el momento de mandarlo a la base de datos hay que pasarlo a int
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            N_Paciente negocio = new N_Paciente();
            Paciente pacAux = new Paciente();

            pacAux.Nombre = Nombre.Text;
            pacAux.Apellido = Apellido.Text;
            pacAux.FechaNacimiento = DateTime.Parse(Nacimiento.Text);
            pacAux.Genero = Genero.SelectedValue;
            pacAux.obraSoc.ID = Convert.ToInt32(ObraSocial.SelectedValue.ToString());
            pacAux.Domicilio = Domicilio.Text;
            pacAux.Celular = Celular.Text;
            pacAux.NroAfiliado = Afiliado.Text;

            pacAux.Usuario.Email = Email.Text;
            pacAux.Usuario.Contrasena = "root";

            negocio.Cargar(pacAux);
            Response.Redirect("A_Dashboard.aspx");
        }
    }
}