using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsectCatalog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace InsectCatalog.Controllers
{
    public class CollectionController : Controller
    {
        public InsectRepository Repo { get; set; }

        public CollectionController() : base()
        {
            Repo = new InsectRepository();
        }

        // GET: Collection
        public ActionResult Index()
        {
            return View();
        }
    }
}