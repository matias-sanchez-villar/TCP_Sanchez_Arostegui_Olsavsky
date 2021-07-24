using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace MedicalTurns.Admin
{
    public partial class A_CargarDisponibilidadHoraria : System.Web.UI.Page
    {
        public List<DisponibilidadHoraria> DHlista = new List<DisponibilidadHoraria>();
        public N_DisponibilidadHoraria DHnegocio = new N_DisponibilidadHoraria();
        public DisponibilidadHoraria disponibilidadHoraria = new DisponibilidadHoraria();

        public List<Medico> Mlista = new List<Medico>();
        public N_Medico Mnegocio = new N_Medico();
        public Medico medico = new Medico();

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioAdmi();
            EliminarDH();

            if (!IsPostBack)
            {
                // Carga la disponibilidad en session
                DHlista = DHnegocio.Listar();
                Session.Add("DisponibilidadHoraria", DHlista);

            }

            listarMedicos();
        }


        protected void UsuarioAdmi()
        {
            if (Session["AdmiSettings"] == null)
            {
                Response.Redirect("../Logindef.aspx", false);
            }
        }

        protected DisponibilidadHoraria RetornarDH()
        {
            int ID = int.Parse(Request.QueryString["ID"]);

            DHlista = (List<DisponibilidadHoraria>)Session["DisponibilidadHoraria"];

            return disponibilidadHoraria = DHlista.Find(x => x.ID == ID);
        }

        protected void EliminarDH()
        {
            try
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["ID"])) && Session["DisponibilidadHoraria"] != null)
                {
                    N_DisponibilidadHoraria negocio = new N_DisponibilidadHoraria();

                    disponibilidadHoraria = RetornarDH();

                    negocio.Eliminar(disponibilidadHoraria);

                    Response.Redirect("A_CargarDisponibilidadHoraria.aspx", false);

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<script> swal('Error!', '" + ex.Message + "','Error').then( () => {"
                                                                                    + "location.href = 'A_Dashboard.aspx'" +
                                                                                "}) </script>");
            }
        }


        public void listarMedicos()
        {
            try
            {
                Mlista = Mnegocio.Listar();

                foreach (dominio.Medico item in Mlista)
                {
                    string nombreAux = item.Nombre.ToString();
                    string apellidoAux = item.Apellido.ToString();
                    string completeName = nombreAux + " " + apellidoAux;
                    string IdMedico = item.ID.ToString();

                    ListItem listItemAux = new ListItem(completeName, IdMedico);
                    ddlMedico.Items.Add(listItemAux);
                }
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<script> swal('Error!', '" + ex.Message + "','Error').then( () => {"
                                                                                    + "location.href = 'A_Dashboard.aspx'" +
                                                                                "}) </script>");

            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                Page.Validate();
                if (!Page.IsValid) return;

                else
                {
                    medico = Mnegocio.BuscarMedicoID(int.Parse(ddlMedico.SelectedItem.Value));

                    disponibilidadHoraria.medicoAux = medico;
                    disponibilidadHoraria.Dia = ddlDia.SelectedValue;
                    disponibilidadHoraria.HoraInicio = TimeSpan.Parse(ddlHoraInicio.SelectedValue);
                    disponibilidadHoraria.HoraFin = TimeSpan.Parse(ddlHoraFin.SelectedValue);

                    if (disponibilidadHoraria.HoraInicio < disponibilidadHoraria.HoraFin)
                    {
                        DHnegocio.Cargar(disponibilidadHoraria);
                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<script> swal('Perfecto!', 'Disponibilidad Horaria Ingresada!','success').then( () => {"
                                                                                        + "location.href = 'A_CargarDisponibilidadHoraria.aspx'" +
                                                                                    "}) </script>");

                    //Response.Redirect("A_CargarDisponibilidadHoraria.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<script> swal('Error!', '" + ex.Message + "','Error').then( () => {"
                                                                                    + "location.href = 'A_Dashboard.aspx'" +
                                                                                "}) </script>");
            }
        }

        protected void ddlDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlHoraInicio.Items.Clear();
            ddlHoraFin.Items.Clear();

            TimeSpan Intervalo = new TimeSpan(01, 00, 00);
            TimeSpan Fin = new TimeSpan(23, 00, 0);
            TimeSpan Inicio = new TimeSpan(00, 00, 0);

            while (Inicio != Fin)
            {

                if (CompararHoras(Inicio))
                {
                     ListItem listItemAux = new ListItem(Inicio.ToString(), Inicio.ToString());
                     ddlHoraInicio.Items.Add(listItemAux);
                     ddlHoraFin.Items.Add(listItemAux);
                }

                Inicio += Intervalo;

            }

            if (CompararHoras(Fin))
            {
                ListItem listItemAux = new ListItem(Fin.ToString(), Fin.ToString());
                ddlHoraInicio.Items.Add(listItemAux);
                ddlHoraFin.Items.Add(listItemAux);
            }

        }

        protected bool CompararHoras(TimeSpan Inicio)
        {
            int ID = int.Parse(ddlMedico.SelectedItem.Value);
            string Dia = (string)ddlDia.SelectedItem.Value;

            DHlista = DHnegocio.ListarIDMedicoFecha(ID, Dia);

            foreach (dominio.DisponibilidadHoraria item in DHlista)
            {

                if (Inicio >= item.HoraInicio && Inicio <= item.HoraFin)
                {
                    return false;
                }
            }

            return true;
        }


    }
}