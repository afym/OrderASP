using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderASP.Models;

namespace OrderASP.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View(GetCategoryCollection());
        }

        [HttpGet]
        public ActionResult New() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Category category) 
        {
            TempData["New"] = "A new category added!!";
            return RedirectToAction("Index");
        }

        private List<Category> GetCategoryCollection() 
        {
            return new List<Category>() { 
                new Category(){Id = 1, Name = "Phones"},
                new Category(){Id = 2, Name = "Books"},
            };
        }
    }
}