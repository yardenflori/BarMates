using BarMates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Services;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DBController.GetUserName() == null)
        {
            Response.Redirect("Default.aspx");
        }

    }
    [WebMethod]
    public static bool SendContactMessage(string message)
    {
        JObject newContactMessage = null;
        bool isSucceeded = true;
        try
        {
            newContactMessage = JsonConvert.DeserializeObject<JObject>(message);
        }
        catch
        {
            isSucceeded = false;
        }
        if (isSucceeded == true)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.HeadersEncoding = new System.Text.UTF8Encoding();
                mail.From = new MailAddress("hiburitcomp@gmail.com", "Bar Mates | 'בר מאטס", new System.Text.UTF8Encoding());              
                mail.To.Add("hiburitcomp@gmail.com");
                mail.Subject = "צור קשר'";
                mail.SubjectEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                string client_name = newContactMessage["client_name"].ToString();
                string phone = newContactMessage["phone"].ToString();
                string email = newContactMessage["email"].ToString();
                string subject = newContactMessage["subject"].ToString();
                string client_content = newContactMessage["client_content"].ToString();

                mail.Body = "<p style=\"direction: rtl;\"><strong>שם מלא: </strong>" + client_name + "</p>" +
                    "<p style=\"direction: rtl;\"><strong>טלפון: </strong>" + phone + " </p>" +
                    "<p style=\"direction: rtl;\"><strong>דואר אלקטרוני: </strong>" + email + "</p>" +
                    "<p style=\"direction: rtl;\"><strong>נושא הפנייה: </strong>" + subject + " </p>" +
                    "<p style=\"direction: rtl;\"><strong>תוכן הפניה:</strong>  " + client_content + "</p>";
                mail.BodyEncoding = new System.Text.UTF8Encoding();
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hiburitcomp@gmail.com", "Hb59036447");
                SmtpServer.Timeout = 5000;
                SmtpServer.Send(mail);
            }
            catch
            {
                isSucceeded = false;
            }
        }
        return isSucceeded;
    }
}