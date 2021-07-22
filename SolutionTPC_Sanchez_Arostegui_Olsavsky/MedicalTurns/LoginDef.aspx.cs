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
    public partial class LoginDef : System.Web.UI.Page
    {
        public Usuario userAux = new Usuario();
        public List<Usuario> userListAux = new List<Usuario>();
        public N_Usuario n_Usuario = new N_Usuario();

        public Medico medicoAux = new Medico();
        public N_Medico negocioMedico = new N_Medico();

        public Paciente pacienteAux = new Paciente();
        public N_Paciente negocioPaciente = new N_Paciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            BorrarSecciones();

            userListAux = n_Usuario.listar();
            Session.Add("listaUsuarios", userListAux);

        }

        protected void BorrarSecciones()
        {
            if (Session["MedicoSettings"] != null)
            {
                Session.Remove("MedicoSettings");
            }
            if (Session["PacienteSettings"] != null)
            {
                Session.Remove("PacienteSettings");
            }
            if (Session["AdmiSettings"] != null)
            {
                Session.Remove("AdmiSettings");
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            Usuario usuAux = new Usuario();

            string emailAux = emailInput.Text;
            string passwordAux = passwordInput.Text;

            usuAux = retornarUsuario(emailAux);

            if (usuAux != null)
            {
                if (usuAux.Contrasena == passwordAux)
                {

                    switch (usuAux.tipoUsuario)
                    {
                        case 1:
                            medicoAux = negocioMedico.BuscarMedicoIDUsuario(usuAux);
                            Session.Add("MedicoSettings", medicoAux);
                            Response.Redirect("Medico/M_Dashboard.aspx");
                            break;
                        case 2:
                            pacienteAux = negocioPaciente.BuscarPacienteIdUsuario(usuAux);
                            Session.Add("PacienteSettings", pacienteAux);
                            Response.Redirect("Paciente/P_Dashboard.aspx");
                            break;
                        case 3:
                            Session.Add("AdmiSettings", true);
                            Response.Redirect("Admin/A_Dashboard.aspx");
                            break;
                    }

                }
                else
                {
                    //marcar la contraseña como incorrecta
                }
            }
            else
            {

            }
                //marcar el email como erroneo
        }

        public Usuario retornarUsuario(string email)
        {

            Usuario usuAux = new Usuario();

            usuAux = userListAux.Find(x => x.Email == email);

            return usuAux;
        }
    }
}