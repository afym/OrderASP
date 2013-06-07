using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderASP.Models;
using OrderASP.Models.Service;

namespace OrderASP.Controllers
{
    public class ProductController : Controller
    {
        private ProductService service;

        public ProductController() 
        {
            service = new ProductService(new OMSDBEntitiesConteiner());
        }

        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        [HttpGet]
        public ActionResult New()
        {
            ViewData["Submit"] = "Create";
            ViewData["Action"] = "New";

            return View("Form", service.GetEntity(0));
        }

        [HttpPost]
        public ActionResult New(Product product)
        {
            Validation(product);

            if (ModelState.IsValid)
            {
                TempData["Message"] = "A new product was added.";

                service.Save(product);

                return RedirectToAction("Index");
            }

            return New();
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ViewData["Submit"] = "Edit";
            ViewData["Action"] = "Edit";
            return View("Form", service.GetEntity(id));
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            Validation(product);

            if (ModelState.IsValid)
            {
                TempData["Message"] = "A product was edited";
                service.Update(product);

                return RedirectToAction("Index");
            }

            return Edit(product.Id);
        }


        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            if (id.Equals(0))
            {
                return RedirectToAction("Index");
            }

            ViewData["id"] = id;

            return View();
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            TempData["Message"] = "A product was removed";
            service.Delete(product.Id);
            return RedirectToAction("Index");
        }

        private void Validation(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
            {
                ModelState.AddModelError("Name", "Is required");
            }
            else if (product.Name.Length < 2 || product.Name.Length > 255)
            {
                ModelState.AddModelError("Name", "Name must have 2 to 255 of length");
            } 
            else if (product.CategoryId.Equals(0))
            {
                ModelState.AddModelError("CategoryId", "Select a category please");
            }
        }
    }
}
