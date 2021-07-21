﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace MedicalTurns.Admin
{
    public partial class A_EnvioEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            N_EmailService emailService = new N_EmailService();
            emailService.armarCorreo(txtEmail.Text, txtAsunto.Text, txtMensaje.Text);

            try
            {
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }

        }
    
    }
}