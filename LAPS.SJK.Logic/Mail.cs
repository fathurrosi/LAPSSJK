using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LAPS.SJK.Dto;


namespace LAPS.SJK.Logic
{
    //public class Mail
    //{
    //    //https://social.msdn.microsoft.com/Forums/azure/en-US/429f90c3-166b-480a-8b2f-ed9752373e18/smtp-service-on-azure?forum=WAVirtualMachinesVirtualNetwork
    //    //https://guidestomicrosoft.com/2016/02/17/configure-a-smtp-server-in-azure/
    //    public static async Task<SendGrid.Response> Send(string subject, string body, string emailto)
    //    {
    //        SendGrid.Response response = null;
    //        //bool result = false;
    //        try
    //        {
    //            //string smtpHost = "";
    //            //int smtpPort = 0;
    //            //string account = "";
    //            //string password = "";
    //            //string mailSender = "";
    //            //string senderText = "";
    //            //List<tbl_setting> list = tbl_settingItem.GetAll();

    //            //tbl_setting item = list.Where(t => t.name == tbl_settingItem._SMPT_HOST).FirstOrDefault();
    //            //if (item != null)
    //            //{
    //            //    smtpHost = item.value.Trim();
    //            //}

    //            //item = list.Where(t => t.name == tbl_settingItem._SMPT_PORT).FirstOrDefault();
    //            //if (item != null)
    //            //{
    //            //    int.TryParse(item.value.Trim(), out smtpPort);
    //            //}

    //            //item = list.Where(t => t.name == tbl_settingItem._SMPT_USERNAME).FirstOrDefault();
    //            //if (item != null)
    //            //{
    //            //    account = item.value.Trim();
    //            //}

    //            //item = list.Where(t => t.name == tbl_settingItem._SMPT_USERPASSWORD).FirstOrDefault();
    //            //if (item != null)
    //            //{
    //            //    password = item.value.Trim();
    //            //}

    //            //item = list.Where(t => t.name == tbl_settingItem._SMPT_MAIL_SENDER).FirstOrDefault();
    //            //if (item != null)
    //            //{
    //            //    mailSender = item.value.Trim();
    //            //}

    //            //item = list.Where(t => t.name == tbl_settingItem._SMPT_TEXT_SENDER).FirstOrDefault();
    //            //if (item != null)
    //            //{
    //            //    senderText = item.value.Trim();
    //            //}

    //            //function main() {
    //            //         getQuote().then((quote) => {
    //            //             console.log(quote);
    //            //         }).catch ((error) => {
    //            //             console.error(error);
    //            //         });
    //            // }

    //            //try { await ThrowAsync(); }
    //            //catch (Exception ex) { Log("Exception handled OK"); }
    //            response = await Execute(subject, emailto, body);

    //            //var client = new SmtpClient
    //            //{
    //            //    Host = smtpHost,
    //            //    Port = smtpPort,
    //            //    EnableSsl = true,
    //            //    DeliveryMethod = SmtpDeliveryMethod.Network,
    //            //    UseDefaultCredentials = false,
    //            //    Timeout = 30 * 1000,
    //            //    Credentials = new NetworkCredential(account, password)
    //            //};

    //            //using (var msg = new MailMessage(new MailAddress(mailSender, senderText), new MailAddress(emailto)))
    //            //{
    //            //    msg.Subject = subject;
    //            //    msg.Body = body;
    //            //    msg.IsBodyHtml = true;
    //            //    client.Send(msg);
    //            //}
    //            //result = true;
    //            Log.Info(string.Format("Email Body :{0}<br /> Sent to {1} successfully", body, emailto));
    //        }
    //        catch (Exception ex)
    //        {
    //            Log.Info(ex.ToString());
    //        }

    //        return response;
    //    }


    //    private static async Task<SendGrid.Response> Execute(string subject, string emailTo, string htmlContent)
    //    {
    //        string emailForm = "";
    //        string textFrom = "";
    //        List<tbl_setting> settingList = tbl_settingItem.GetAll();
    //        tbl_setting item = settingList.Where(t => t.name == tbl_settingItem._SMPT_MAIL_SENDER).FirstOrDefault();
    //        if (item != null)
    //        {
    //            emailForm = item.value.Trim();
    //        }

    //        item = settingList.Where(t => t.name == tbl_settingItem._SMPT_TEXT_SENDER).FirstOrDefault();
    //        if (item != null)
    //        {
    //            textFrom = item.value.Trim();
    //        }


    //        var apiKey = ConfigReader.SendGrid_API_Key;

    //        var client = new SendGridClient(apiKey);

    //        var from = new EmailAddress(emailForm, textFrom);

    //        var to = new EmailAddress(emailTo);

    //        //Log.Info("CreateSingleEmail");

    //        var msg = MailHelper.CreateSingleEmail(from, to, subject, string.Empty, htmlContent);

    //        SendGrid.Response response = await client.SendEmailAsync(msg);

    //        string result = $"Statuscode {(int)response.StatusCode}: {response.StatusCode}";
    //        result += await response.Body.ReadAsStringAsync();

    //        Log.Info(result);

    //        return response;
    //    }
    //}
}
