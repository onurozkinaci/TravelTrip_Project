using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context context = new Context(); //Db Context uzerinden ihtiyac duyulan DbSetlere ve onlarin propertylerine erisebilmek icin.

        public ActionResult Index()
        {
            var values = context.Hakkimizdas.ToList(); //Hakkimizdas DbSet'inin propertylerine erisim saglanir.
            return View(values);
        }
    }
}