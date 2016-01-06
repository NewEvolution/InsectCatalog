using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsectCatalog.Models;

namespace InsectCatalog.Controllers
{
    public class HomeController : Controller
    {
        public InsectRepository Repo { get; set; }

        public HomeController() : base()
        {
            Repo = new InsectRepository();
        }

        public ActionResult Index()
        {
            //Insect splashInsect = Repo.GetRandomInsect();
            //return View(splashInsect);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}