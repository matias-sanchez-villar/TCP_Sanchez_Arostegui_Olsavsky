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
    public partial class A_ListarPacientes : System.Web.UI.Page
    {
        public List<Paciente> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            N_Paciente paciente = new N_Paciente();

            lista = paciente.Listar();

            Session.Add("Paciente", lista);

        }
    }
}