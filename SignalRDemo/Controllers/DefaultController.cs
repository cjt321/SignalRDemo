using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalRDemo.SignalR;

namespace SignalRDemo.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            string connId = Request["connId"] ?? "";

            Notifier.ServerSend2ClientMethod(connId, Math.Round(1000.0) + "");

            return View();
        }
    }
}