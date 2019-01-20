using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardSystem.Models;

namespace CardSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly CardSystemContext db = new CardSystemContext();
        public ActionResult Index()
        {
            
            return View(db.Items.ToList());
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
        [HttpGet]
        public JsonResult AddCart(int id)
        {
            Item Toadd =db.Items.Find(id);
            if (Toadd != null)
            {
                return Json(new {Toadd}, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {

                state = 404,
                message = "Bele mehsul yoxdur, bala"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}