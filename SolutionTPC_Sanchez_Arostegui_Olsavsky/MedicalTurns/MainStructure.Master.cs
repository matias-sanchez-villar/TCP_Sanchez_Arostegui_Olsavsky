using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio; //Usamos negocio para poder traer los objetos de la BD
using dominio; //Usamos dominio tambien para tener las clases

namespace MedicalTurns
{
    public partial class MainStructure : System.Web.UI.MasterPage
    {
        public List<Medico> lista;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                N_Medico medico = new N_Medico();
                lista = medico.Listar();
            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }
        }

    }
}