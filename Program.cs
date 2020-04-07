using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using AuroraCommerceApp.BAL;
using System.Configuration;
using System.Net.Mail;
using System.IO;

namespace AuroraCommerceApp
{
    public class Program
    {

        private const string CLASS_TYPE_NAME = "AuroraCommerceApp.Program";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            string message = "";
            string frameWorkVersion = "Running under .NET Framework Version " + Environment.Version;

            Console.WriteLine(frameWorkVersion);

            Console.WriteLine(CLASS_TYPE_NAME);
            DateTime startTime = DateTime.Now;
            Console.WriteLine("Program starting at " + startTime);

            message += string.Format("" + CLASS_TYPE_NAME);
            message += Environment.NewLine;

            message += string.Format("" + frameWorkVersion);
            message += Environment.NewLine;

            message += string.Format("Program starting at " + startTime);
            message += Environment.NewLine;
            log.Info(message);
            string EmailuserName = ConfigurationManager.AppSettings["EmailUsername"];
            string Emailpassword = ConfigurationManager.AppSettings["EmailPassword"];

            //Start:
            try
            {
                APIAuroraBAL apiaurorabal = new APIAuroraBAL();
                apiaurorabal.RunReport();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MailMessage message1 = new MailMessage
                {
                    Subject = "JD.FeedManager.AuroraCommerceAPP did not start correctly.",
                    From = new MailAddress("webmaster@jdplc.com", "WebCommerceInternal")
                };
                //string adress = "<babu.danimireddi@jdplc.com>,<sumanth.boddu@jdplc.com>";
                string adress = ConfigurationManager.AppSettings["Mails"];
                message1.To.Add(adress.Replace(";", ","));
                message1.Priority = MailPriority.High;
                message1.IsBodyHtml = true;
                message1.Body = "There was a fatal error processing the config or opening the log file. <div><b> The feed was not generated.</b></div>";
                message1.Body += Environment.NewLine;
                message1.Body += "<div><b><font color='red'> <u>Exception</u> : " + ex.Message + "</font></b></div>";
                message1.Body += Environment.NewLine;
                var directory = new DirectoryInfo(ConfigurationManager.AppSettings["LogPath"]);
                var myFile = (from f in directory.GetFiles()
                              orderby f.LastWriteTime descending
                              select f).First();
                string LogMsg = File.ReadAllText(myFile.FullName);
                message1.Body += LogMsg;
                message1.Body += "Program Ending at :" + DateTime.Now;
                SmtpClient smptClient = new SmtpClient("smtp.sendgrid.net", 25);
                smptClient.UseDefaultCredentials = true;
                smptClient.Credentials = new System.Net.NetworkCredential(EmailuserName, Emailpassword);
                smptClient.Send(message1);

                throw;
            }


            DateTime EndTime = DateTime.Now;

            Console.WriteLine("Program Ending at " + EndTime);

            message += string.Format("Program Ending at " + EndTime);
            message += Environment.NewLine;
            log.Info(message);

            MailMessage Mainmessage = new MailMessage
            {
                Subject = "JD.FeedManager.AuroraCommerceAPP .",
                From = new MailAddress("webmaster@jdplc.com", "WebCommerceInternal")
            };

            string adress1 = ConfigurationManager.AppSettings["Mails"];
            Mainmessage.To.Add(adress1.Replace(";", ","));

            var directory1 = new DirectoryInfo(ConfigurationManager.AppSettings["LogPath"]);
            var myFile1 = (from f in directory1.GetFiles()
                          orderby f.LastWriteTime descending
                          select f).First();
            string LogMsg1 = File.ReadAllText(myFile1.FullName);
            Mainmessage.Body += LogMsg1;
            Mainmessage.Body += "Program Ending at :" + DateTime.Now;
            SmtpClient smptClient1 = new SmtpClient("smtp.sendgrid.net", 25);
            smptClient1.UseDefaultCredentials = true;
            smptClient1.Credentials = new System.Net.NetworkCredential(EmailuserName, Emailpassword);
            smptClient1.Send(Mainmessage);
        }
    }
}
