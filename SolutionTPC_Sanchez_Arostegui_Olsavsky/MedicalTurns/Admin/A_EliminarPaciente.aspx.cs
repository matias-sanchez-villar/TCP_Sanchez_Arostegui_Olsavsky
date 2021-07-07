using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalTurns.Admin
{
    public partial class A_EliminarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        /*
        protected void EliminarPaciente_Click(object sender, EventArgs e)
        {
            int IDPaciente = int.Parse(Request.QueryString["ID"]);
            N_Paciente negocio = new N_Paciente();

            pacienteAEliminar = RetornarPaciente();

            pacienteAEliminar.ID = IDPaciente;


            negocio.Eliminar(pacienteAEliminar);
            Response.Redirect("A_Dashboard.aspx");


        }

        protected Paciente RetornarPaciente()
        {
            int ID = int.Parse(Request.QueryString["ID"]);

            listaPaciente = (List<Paciente>)Session["Paciente"];

            pacienteAEliminar = new Paciente();

            return pacienteAEliminar = listaPaciente.Find(x => x.ID == ID);
        }
        */
    }
}