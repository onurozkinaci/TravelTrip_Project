using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class DefaultController : Controller
    {
        Context context = new Context();

        // GET: Default
        public ActionResult Index()
        {
            var values = context.Blogs.OrderByDescending(x=>x.ID).Take(8).ToList(); //bloglari view'e iletip bloglarin resimlerini anasayfada slider icin kullaniyoruz.Son 8 blogun resimleri baz alinacak, bu sebeple "OrderByDescending(x=>x.ID).Take(8)" kullanimina basvuruldu.
            return View(values);
        }
        public ActionResult About() {
            return View();
        }

        //Partial View olusturmak icin;
        public PartialViewResult Partial1() {
            var values = context.Blogs.OrderByDescending(x=>x.ID).Take(2).ToList(); //desc (buyukten kucuge) siralanan son 2 blog getirilir.
            return PartialView(values);
        }

        public PartialViewResult Partial2()
        {
            var values = context.Blogs.Where(x => x.ID == 2).ToList();
            return PartialView(values);
        }
        public PartialViewResult Partial3() {
            var values = context.Blogs.OrderByDescending(x=>x.ID).Take(10).ToList(); //son 10 blogu getirmek icin
            return PartialView(values);
        }
        public PartialViewResult Partial4()
        {
            var values = context.Blogs.Take(3).ToList(); //ilk 3 blogu getirmek icin
            return PartialView(values);
        }

        public PartialViewResult Partial5() {
            var values = context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList(); //son 3 blogu getirmek icin
            return PartialView(values);
        }
    }
}