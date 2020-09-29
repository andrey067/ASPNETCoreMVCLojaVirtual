using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(ContatoEmail contato)
        {
            /*
             * Configurando requisicao SMTP do gmail
             *  Servidor que vai enviar a mensagem
             */

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("audrey.ernesto.lima@gmail.com","andrey067");
            smtp.EnableSsl = true;

            /*
             * MailMEssage -> construir a mesagem
             */

            MailMessage mensagem = new MailMessage();

        }
    }
}
