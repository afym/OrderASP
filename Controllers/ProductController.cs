using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OrderASP.Models;

namespace OrderASP.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View(GetProductCollection());
        }

        [HttpGet]
        public ActionResult New() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Product product) 
        {
            TempData["New"] = "A new product added!!";
            return RedirectToAction("Index");
        }

        private List<Product> GetProductCollection() 
        {
            return new List<Product>() { 
            new Product(){Id = 1, Name = "Phone", InStock = true},
            new Product(){Id = 2, Name = "Mobile Phone", InStock = true},
            new Product(){Id = 3, Name = "Tablet", InStock = false},
            };
        }
    }
}
