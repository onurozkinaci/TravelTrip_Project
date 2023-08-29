﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context context = new Context();

        //Pagination control is applied before sending the data to view in order to show max 10 data in each page by default;
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            List<Blog> allBlogs = context.Blogs.ToList();
            int totalBlogs = allBlogs.Count;
            List<Blog> paginatedBlogs = allBlogs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            ViewBag.TotalBlogs = totalBlogs;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            return View(paginatedBlogs);
        }
        #region AddNewBlog
        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewBlog(Blog newBlog)
        {
            context.Blogs.Add(newBlog);
            context.SaveChanges();
            return RedirectToAction("Index"); //Index action'ina yonlendirip eklenen blogu listeleyecek.
        }
        #endregion 

        public ActionResult DeleteBlog(int id) 
        {
            var blog = context.Blogs.Find(id); //found blog by it's Primary Key
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index"); //Index action'ina yonlendirip silinen blogu listeleyecek.
        }

        #region UpdatingTheBlog
        public ActionResult FindBlog(int id)
        {
            var blog = context.Blogs.Find(id); //found blog
            return View("FindBlog", blog);
        }
        public ActionResult BlogUpdate(Blog updatedBlog)
        {
            #region Not
             /*'Find()' ile bulunan nesne context'e attach edilir ve bu nesne uzerinde yaptigin degisiklikler context
             tarafindan izlenip(tracked) direkt context'i etkiler. Boylece, nesneye ait propertylerin yeni 
             degerlerini atadiktan sonra direkt olarak `context.SaveChanges();` kullanimi ile Db uzerindeki 
             guncellemeyi de saglayabilirsin;*/
            #endregion
            var blog = context.Blogs.Find(updatedBlog.ID); //the blog which is going to be updated is found.
            blog.Description = updatedBlog.Description;
            blog.Title = updatedBlog.Title;
            blog.BlogImage = updatedBlog.BlogImage;
            blog.Date = updatedBlog.Date;
            context.SaveChanges();
            return RedirectToAction("Index"); //Index action'ina yonlendirip guncellenen blogu listeleyecek.
        }
        #endregion

        public ActionResult CommentList()
        {
            var comments = context.Yorumlars.ToList();
            return View(comments);
        }
    }
}