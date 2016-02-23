using MessagingApplication.MessagingServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessagingApplication.Controllers
{
    public class HomeController : Controller
    {
        Service1Client client = new Service1Client();

        public ActionResult Index()
        {
            var messages=client.GetMessages();
            client.Close();
            return View(messages.ToList<Message>());
        }

        public ActionResult Add(string message)
        {
            var messages = client.AddMessages(message);
            client.Close();
            return PartialView("_Messages", messages.ToList());
        }

        public ActionResult Delete(string ID)
        {
            var msgs = client.DeleteMessages(ID);
            client.Close();
            return PartialView("_Messages", msgs.ToList());
        }

       
    }
}
