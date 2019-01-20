using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using CookieTest.Models;


namespace CookieTest.Controllers
{
    public class HomeController : Controller
    {
        private  readonly CookieTestContext db = new CookieTestContext();
        public ActionResult Index()
        {

            HttpCookie NewCookie = Request.Cookies["credentials"];
            if (NewCookie!=null)
            {
                string password = NewCookie.Values["up"].ToString();
;                User usr = db.Users.FirstOrDefault(u => u.Password == password);
                if (usr!=null)
                {
                    Session["Logged"] = usr.Id;
                    RedirectToAction("index", "home");
                }

            }
            return View();
        }

        public ActionResult About()
        {
            //HttpCookie UserCookie = new HttpCookie("user","1");
           
            //UserCookie.Expires.AddDays(10);
            
            //UserCookie.Domain = "kamran";
            //UserCookie.Path = "Kamran/Mirzeyev";
            //HttpContext.Response.SetCookie(UserCookie);
            //HttpCookie NewCookie = Request.Cookies["user"];
            

            //return Content(NewCookie.Value);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GeneratePass( )

        {
            string pass = Crypto.HashPassword("123");

            return Content(pass);
        }

        public ActionResult Login(string username, string password)
        {

            if (!string.IsNullOrEmpty(username)&& !string.IsNullOrEmpty(password))
            {
              User logged=  db.Users.Where(u => u.Name == username ).FirstOrDefault();

                if (logged!=null)
                {
                    if (Crypto.VerifyHashedPassword(logged.Password,password))
                    {
                        HttpCookie cred = new HttpCookie("credentials");
                        cred.Values["un"] = logged.Name;
                        cred.Values["up"] = logged.Password;
                        HttpContext.Response.SetCookie(cred);
                        HttpCookie NewCookie = Request.Cookies["credentials"];
                        Session["Logged"] = logged.Id;

                        return RedirectToAction("Index");
                    }
                    
                }
            }

            return HttpNotFound();
        }
    }
}