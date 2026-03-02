using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Shared
{
    public class GMailer
    {
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        // Propriétés de l'email
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        static GMailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 587; // 587 pour TLS, 465 pour SSL
            GmailSSL = true;
        }

        public void Send()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

            try
            {
                using (var message = new MailMessage(GmailUsername, ToEmail))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;

                    smtp.Send(message);
                }
            }
            catch (SmtpException ex)
            {
                throw new Exception($"Erreur SMTP lors de l'envoi de l'email : {ex.Message}", ex);
            }
            finally
            {
                smtp.Dispose();
            }
        }

        public static void senMail(string destinataire, string sujet, string corps, bool isHtml = false)
        {
            try
            {
                GMailer mailer = new GMailer();
                mailer.ToEmail = destinataire;
                mailer.Subject = sujet;
                mailer.Body = corps;
                mailer.IsHtml = isHtml;

                mailer.Send();

                Console.WriteLine($"Email envoyé avec succès à {destinataire}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'envoi de l'email à {destinataire} : {ex.Message}", ex);
            }
        }
    }
}