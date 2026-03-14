using System;
using System.Net;
using System.Net.Mail;

namespace AppGestionCahierTexte.Shared
{
    public class GMailer
    {
        // ── Configuration SMTP (statique) ─────────────────────────────────────
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; } = "smtp.gmail.com";
        public static int GmailPort { get; set; } = 587;
        public static bool GmailSSL { get; set; } = true;

        // ── Propriétés du message ─────────────────────────────────────────────
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        // ── Envoi instance ────────────────────────────────────────────────────
        public void Send()
        {
            using (var smtp = new SmtpClient
            {
                Host = GmailHost,
                Port = GmailPort,
                EnableSsl = GmailSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(GmailUsername, GmailPassword)
            })
            using (var message = new MailMessage(GmailUsername, ToEmail)
            {
                Subject = Subject,
                Body = Body,
                IsBodyHtml = IsHtml
            })
            {
                try
                {
                    smtp.Send(message);
                }
                catch (SmtpException ex)
                {
                    throw new Exception($"Erreur SMTP : {ex.Message}", ex);
                }
            }
        }

        // ── Envoi statique (helper) ───────────────────────────────────────────
        public static void SendMail(string destinataire, string sujet, string corps, bool isHtml = false)
        {
            try
            {
                new GMailer
                {
                    ToEmail = destinataire,
                    Subject = sujet,
                    Body = corps,
                    IsHtml = isHtml
                }.Send();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur envoi email à {destinataire} : {ex.Message}", ex);
            }
        }
    }
}