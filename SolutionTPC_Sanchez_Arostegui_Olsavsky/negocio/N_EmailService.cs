using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;


namespace negocio
{
    public class N_EmailService
    {
        
            private MailMessage email;
            private SmtpClient server;

            public N_EmailService()
            {
                server = new SmtpClient();
                server.Credentials = new NetworkCredential("mmediturns@gmail.com", "mediturns123");
                server.EnableSsl = true;
                server.Port = 587;
                server.Host = "smtp.gmail.com";
            }

            public void armarCorreo(string emailDestino, string asunto, string cuerpo)
            {
                email = new MailMessage();
                email.From = new MailAddress("noresponder@ecommerceprogramacioniii.com");
                email.To.Add(emailDestino);
                email.Subject = asunto;
                email.IsBodyHtml = true;
                email.Body = "<h1>Datos de Contacto Mediturnos</h1> <br>Hola, recibimos tus datos de contacto, te contactaremos pronto";
                //email.Body = cuerpo;

            }

            public void enviarEmail()
            {
                try
                {
                    server.Send(email);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        
    }
}
