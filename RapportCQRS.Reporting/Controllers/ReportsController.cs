//namespace CSharp.AspNetCoreDemo.Controllers
//{
//    using Microsoft.AspNetCore.Mvc;
//    using System.Net;
//    using System.Net.Mail;
//    using Telerik.Reporting.Services;
//    using Telerik.Reporting.Services.AspNetCore;

//    [Route("api/reports")]
//    public class ReportsController : ReportsControllerBase
//    {
//        public ReportsController(IReportServiceConfiguration reportServiceConfiguration)
//            : base()
//        {
//            this.ReportServiceConfiguration = reportServiceConfiguration;
//        }

//        protected override HttpStatusCode SendMailMessage(MailMessage mailMessage)
//        {

//            using (var client = new SmtpClient("smtp-mail.outlook.com", 587))
//            {
//                string _sender = "klein.houzin@outlook.com";
//                string _password = "Cl@r1ty#20";

//                client.DeliveryMethod = SmtpDeliveryMethod.Network;

//                client.UseDefaultCredentials = false;

//                System.Net.NetworkCredential credentials =
//                    new System.Net.NetworkCredential(_sender, _password);
//                client.EnableSsl = true;
//                client.Credentials = credentials;


//                client.Send(mailMessage);
//            }

//            return HttpStatusCode.OK;
//        }
//    }
//}
