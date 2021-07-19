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

        protected void Page_Load(object sender, EventArgs e)
        {
            userListAux = n_Usuario.listar();
            Session.Add("listaUsuarios", userListAux);

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
                            Response.Redirect("Medico/M_Dashboard.aspx");
                            break;
                        case 2:
                            Response.Redirect("Paciente/P_Dashboard.aspx");
                            break;
                        case 3:
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