using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderASP.Models;
using System.Data.Objects.SqlClient;

namespace OrderASP.Models.Service
{
    public class CategoryService : ICategory
    {
        private OMSDBEntitiesConteiner context;

        public CategoryService(OMSDBEntitiesConteiner context) 
        {
            this.context = context;
        }

        public List<Category> GetAll() 
        {
            return context.Category.ToList();
        }

        public void Save(Category category) 
        {
            context.Category.Add(category);
            context.SaveChanges();
        }

        public void Update(Category category)
        {
            Category categoryEntity = GetEntity(category.Id);
            categoryEntity.Name = category.Name;
            categoryEntity.Description = category.Description;

            context.SaveChanges();
        }

        public Category GetEntity(int id) 
        {
            Category category;

            if (id.Equals(0))
            {
                category = new Category();
            }
            else 
            {
                category = context.Category.First(c => c.Id == id);
            }

            return category;
        }

        public bool Delete(int id) 
        {
            Category category = GetEntity(id);

            try
            {
                context.Category.Remove(category);
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<Category> GetByName(string name) 
        {
            context.Configuration.ProxyCreationEnabled = false;

            string index = "%" + name  + "%";
            var categories = context.Category.Where(
                                c => SqlFunctions.PatIndex(index.ToLower(), c.Name.ToLower()) > 0).ToList();

            return categories;
        }
    }
}
