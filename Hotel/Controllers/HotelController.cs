using Hotel.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class HotelController : Controller
    {
        // HotelContextCls hobj = new HotelContextCls(); <--This for Model folder class in this Project
        
        ServiceReference1.Service1Client HS = new ServiceReference1.Service1Client();
        static List<SelectListItem> countries = null;
        static List<SelectListItem> cit = null;
        static List<SelectListItem> hid = null;

        static List<SelectListItem> rtid = null;

        public ActionResult Dashboard()
        {
            return View();
        }
        
        
        
        
        // GET: Hotel
        public ActionResult Index()
        {
            string[] c = HS.GetCountries();
            countries = new List<SelectListItem>();
            for (int i = 0; i < c.Length; i++)
            {
                countries.Add(new SelectListItem { Text = c[i], Value = c[i] });
            }

            ViewBag.countries = countries;
            return View();              
        }

        public JsonResult FetchState(string CountryName)
        {
            string[] s = HS.GetCities(CountryName);
            cit = new List<SelectListItem>();
            for (int i = 0; i < s.Length; i++)
            {
                cit.Add(new SelectListItem { Text = s[i], Value = s[i] });
            }
            //ViewBag.states = states;
            return Json(cit, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
       public ActionResult Index(ServiceReference1.HotelDetails ADhotel)
        {
            ViewBag.countries = countries;
            Response.Cookies.Add(new HttpCookie("HotelId", ADhotel.HotelId));
            ViewBag.msg = HS.Addhotel(ADhotel);
            ModelState.Clear();
            return View();

            //return RedirectToAction("Indexroom", "Hotel");
        }






        public ActionResult Indexroom()
        {
            string[] c = HS.Gethoteroomtype();
            rtid = new List<SelectListItem>();
            for (int i = 0; i < c.Length; i++)
            {
                rtid.Add(new SelectListItem { Text = c[i], Value = c[i] });
            }

            ViewBag.roomtypeid = rtid;
            return View();
           
        }

      

        public ActionResult Updatehotel()
        {
            //List<SelectListItem> items = new List<SelectListItem>();
            //items.Add(new SelectListItem { Text = "IT", Value = "1" });
            //items.Add(new SelectListItem { Text = "HR", Value = "2" });
            //items.Add(new SelectListItem { Text = "Payroll", Value = "2" });
            //ViewBag.Departments = items;

            string[] c = HS.GetHoteIdies();
            hid = new List<SelectListItem>();
            for (int i = 0; i < c.Length; i++)
            {
                hid.Add(new SelectListItem { Text = c[i], Value = c[i] });
            }

            ViewBag.hotelid = hid;
            return View();


        }

        [HttpPost]

        public ActionResult Updatehotel(ServiceReference1.HotelDetails Uphotel)
        {
            //ViewBag.msg = HS.up(Uphotel);
            ViewBag.hotelid = hid;
            ViewBag.ms = HS.Upadtehotel(Uphotel);
            ModelState.Clear();
            return View();
        }





        public ActionResult Gethoteldetails()
        {
            HotelDetails hd = new HotelDetails();

            return View(hd);

        }

        public JsonResult JJ(string x)
        {
            HotelDetails T = null;
            ServiceReference1.Service1Client S = new Service1Client();
            T = S.GetHotelDetails(x);
            
            return Json(T, JsonRequestBehavior.AllowGet);
        }





        //public ActionResult Findhote()
        //{
        //    return View();
        //}









        public ActionResult DeleteHotel()
        {
            string[] c = HS.GetHoteIdies();
            hid = new List<SelectListItem>();
            for (int i = 0; i < c.Length; i++)
            {
                hid.Add(new SelectListItem { Text = c[i], Value = c[i] });
            }

            ViewBag.hotelid = hid;
            return View();

            
        }




        [HttpPost]
        public ActionResult DeleteHotel(ServiceReference1.HotelDetails Deh)
        {
            ViewBag.msg = HS.Removehotel(Deh.HotelId);
            return View();
        }



        [HttpGet]
        public ActionResult DisplayHotels()
        {
            var dis = HS.getallhotel();
            return View(dis);
        }

        
     


    }
}