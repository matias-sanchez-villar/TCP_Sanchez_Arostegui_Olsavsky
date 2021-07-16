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
            if (!IsPostBack)
            {
                // Carga la disponibilidad en session
                DHlista = DHnegocio.Listar();
                Session.Add("DisponibilidadHoraria", DHlista);

            }

            listarMedicos();
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

            medico = Mnegocio.BuscarMedicoID(int.Parse(ddlMedico.SelectedItem.Value));

            disponibilidadHoraria.medicoAux = medico;
            disponibilidadHoraria.Dia = ddlDia.SelectedValue;
            disponibilidadHoraria.HoraInicio = TimeSpan.Parse(HorarioInicio.Text);
            disponibilidadHoraria.HoraFin = TimeSpan.Parse(HorarioFin.Text);

            DHnegocio.Cargar(disponibilidadHoraria);
        }
    }
}