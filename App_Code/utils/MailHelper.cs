using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail; 

/// <summary>
/// Summary description for MailHelper
/// </summary>
public class MailHelper
{
    public MailHelper()
    {
    }
    public static String sendMail(String recipient, String name, String password)
    {
        string msgBody = "Hello " + name + " , Your Password is <b>" + password + "</b>";
        try
        {
            string fromEmail = "mohapatradadu@gmail.com";
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                using (MailMessage mm = new MailMessage(fromEmail, recipient))
                {
                    // login credential
                    SmtpClient serverobj = new SmtpClient();
                    serverobj.Credentials = new NetworkCredential(fromEmail, "dadududu");
                    serverobj.Port = 587;
                    serverobj.Host = "smtp.gmail.com";
                    serverobj.EnableSsl = true;

                    // message design 
                    mm.From = new MailAddress(fromEmail, "MakeWay",
                        System.Text.Encoding.UTF8);
                    mm.To.Add(recipient);
                    mm.Subject = " Getting Password ";
                    mm.IsBodyHtml = true;
                    mm.Body = msgBody;

                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    serverobj.Send(mm);

                    return "success";

                }
            }
            else
            {
                return "Failure";
            }


        }
        catch (Exception ex)
        {
            return ex.Message;

        }

    }
}