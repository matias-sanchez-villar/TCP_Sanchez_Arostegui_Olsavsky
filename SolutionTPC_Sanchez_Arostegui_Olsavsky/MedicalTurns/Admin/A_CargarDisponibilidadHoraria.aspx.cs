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
        public DisponibilidadHoraria DisponibilidadHoraria = new DisponibilidadHoraria();

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
        }
    }
}