using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solution.Presentation.Models;
using System.Net;
using System.Net.Mail;




namespace Solution.Presentation.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }
     [HttpPost]
        public ActionResult Index(Solution.Presentation.Models.gmail model)
        {


            MailMessage mm = new MailMessage("rubenztar@gmail.com", model.To);

            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("rubenztar@gmail.com", "thaer22094531");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail has been sent Successfully";


            return View();
        }
    }
}