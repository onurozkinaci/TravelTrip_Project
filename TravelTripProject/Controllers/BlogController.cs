using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        Context context = new Context();
        BlogYorum blogYorum = new BlogYorum(); //this class is created to get values from two tables on the db in one view('BlogDetail.cshtml'). It can be used for many needs.

        // GET: Blog
        public ActionResult Index()
        {
            //var blogs = context.Blogs.ToList(); //var blogs yerine List<Blog> da kullanilabilir.
            blogYorum.Deger1 = context.Blogs.ToList();
            blogYorum.Deger3 = context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList(); //son 3 blogu dondurur.
            //------
            blogYorum.Deger4 = context.Yorumlars.OrderByDescending(x => x.ID).Take(3).ToList(); //son 3 yorumu dondurur.
            //------
            return View(blogYorum);
        }


        public ActionResult BlogDetail(int id)
        {
            //var foundBlog = context.Blogs.Where(x => x.ID == id).ToList(); //finding the matched blog with LINQ query.
            blogYorum.Deger1 = context.Blogs.Where(x => x.ID == id).ToList();
            blogYorum.Deger2 = context.Yorumlars.Where(x => x.BlogId == id).ToList();
            //----------
            blogYorum.Deger3 = context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList(); //son 3 blogu dondurur.
            blogYorum.Deger4 = context.Yorumlars.OrderByDescending(x => x.ID).Take(3).ToList(); //son 3 yorumu dondurur.
            //----------
            return View(blogYorum);
        }

        #region AddComment
        #region Not
        /* BlogDetail(int id) action metodu cagrildiginda iletilen 'id' parametresi ayni isimle 'MakeComment()' partial view metoduna verildiginde de erisilebilirdir cunku MakeComment partial view'i bu BlogDetail view'i icerisinde cagrilmaktadir. Ayni url context'inde bulundugundan, url uzerinden iletilen 'id' degerine bu view icerisinde cagrilan diger partial viewler de parametre adini ayni sekilde kullanarak erisebilir konumdadir.Bu baglamda, BlogDetail(int id) metodu cagrildiginda iletilmis olan ve id parametresine atanan blog id'si, bu metodun 
          dondurdugu view icerisinde cagrilan partial view metodu ('MakeComment()') icin de erisilebilir olacaktir.*/
        #endregion
        [HttpGet]
        public PartialViewResult MakeComment(int id)
        {
            ViewBag.value = id; //Controller'dan view'e veri tasimak icin kullanildi.
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult MakeComment(Yorumlar yorum)
        {
            context.Yorumlars.Add(yorum);
            context.SaveChanges();
            return PartialView();
        }
        #endregion
    }
}