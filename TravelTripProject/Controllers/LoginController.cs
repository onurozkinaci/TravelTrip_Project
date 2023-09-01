using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        #region Login Islemleri
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var infos = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (infos != null)
            {
                FormsAuthentication.SetAuthCookie(infos.Username, false); //cerez atamasi yapilir.
                Session["Kullanici"] = infos.Username.ToString(); //login olan kullanici icin session atamasi yapilir.
                return RedirectToAction("Index", "Admin");
            }
            else
                return View();
        }
        #endregion
        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); //removes the form-authentication ticket from the browser which is created when the user logs in with the usage of "SetAuthCookie()" at the above 'Login()' function.
            return RedirectToAction("Login","Login"); //tekrar login sayfasina yonlendirir.
        }
    }
}