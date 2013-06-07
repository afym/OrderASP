using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderASP.Models.Service;
using OrderASP.Models;

namespace OrderASP.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryService service;

        public CategoryController() 
        {
            service = new CategoryService(new OMSDBEntitiesConteiner());
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
        public ActionResult New(Category category) 
        {
            Validation(category);

            if(ModelState.IsValid)
            {
                TempData["Message"] = "A new category was added.";
                service.Save(category);

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
        public ActionResult Edit(Category category) 
        {
            Validation(category);

            if (ModelState.IsValid) 
            {
                TempData["Message"] = "A category was edited";
                service.Update(category);

                return RedirectToAction("Index");
            }

            return Edit(category.Id);
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
        public ActionResult Delete(Category category)
        {
            bool delete = service.Delete(category.Id);

            if (delete)
            {
                TempData["Message"] = "A category was removed";
            }
            else
            {
                TempData["Error"] = "You can not remove " + category.Name + ". Does category have products ?";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Getcategories()
        {
            var name = Request.QueryString["categoryName"];

            var categories = service.GetByName(name);

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        private void Validation(Category category) 
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                ModelState.AddModelError("Name", "Is required");
            }
            else if (category.Name.Length < 2 || category.Name.Length > 255)
            {
                ModelState.AddModelError("Name", "Name must have 2 to 255 of length");
            }
        }
    }
}