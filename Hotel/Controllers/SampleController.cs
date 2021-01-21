using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DemoMaster()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }
    }
}