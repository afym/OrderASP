using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderASP.Models.Service
{
    public class ProductService : IProduct
    {
        private OMSDBEntitiesConteiner context;

        public ProductService(OMSDBEntitiesConteiner context) 
        {
            this.context = context;
        }

        public List<Product> GetAll()
        {
            return context.Product.ToList();
        }

        public void Save(Product product) 
        {
            context.Product.Add(product);
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            Product productEntity = GetEntity(product.Id);
            productEntity.Name = product.Name;
            productEntity.Available = product.Available;
            productEntity.Stock = product.Stock;
            productEntity.CategoryId = product.CategoryId;

            context.SaveChanges();
        }

        public Product GetEntity(int id)
        {
            Product product;

            if (id.Equals(0))
            {
                product = new Product();
                product.SetDefault();
            }
            else
            {
                product = context.Product.First(c => c.Id == id);
            }

            return product;
        }

        public void Delete(int id)
        {
            Product product = GetEntity(id);
            context.Product.Remove(product);
            context.SaveChanges();
        }
    }
}