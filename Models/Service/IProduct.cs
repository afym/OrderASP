using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderASP.Models.Service
{
    interface IProduct
    {
        /// <summary>
        /// Get all the products
        /// </summary>
        /// <returns>List<Product></returns>
        List<Product> GetAll();
        /// <summary>
        /// Save a new product
        /// </summary>
        /// <param name="product">Product</param>
        void Save(Product product);
        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product">Product</param>
        void Update(Product product);
        /// <summary>
        /// Get an identity
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Product</returns>
        Product GetEntity(int id);
        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">int</param>
        void Delete(int id);
    }
}
