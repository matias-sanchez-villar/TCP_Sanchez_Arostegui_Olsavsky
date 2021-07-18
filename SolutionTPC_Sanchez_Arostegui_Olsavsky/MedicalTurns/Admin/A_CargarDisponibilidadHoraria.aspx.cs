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
            EliminarDH();

            if (!IsPostBack)
            {
                // Carga la disponibilidad en session
                DHlista = DHnegocio.Listar();
                Session.Add("DisponibilidadHoraria", DHlista);

            }

            listarMedicos();
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

                    Response.Redirect("A_CargarDisponibilidadHoraria.aspx");

                }
            }
            catch (Exception ex)
            {
                throw ex;
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

                throw ex;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) return;

            else
            {
                medico = Mnegocio.BuscarMedicoID(int.Parse(ddlMedico.SelectedItem.Value));

                disponibilidadHoraria.medicoAux = medico;
                disponibilidadHoraria.Dia = ddlDia.SelectedValue;
                disponibilidadHoraria.HoraInicio = TimeSpan.Parse(HorarioInicio.Text);
                disponibilidadHoraria.HoraFin = TimeSpan.Parse(HorarioFin.Text);

                DHnegocio.Cargar(disponibilidadHoraria);

                Response.Redirect("A_CargarDisponibilidadHoraria.aspx");
            }
        }
    }
}