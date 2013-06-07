using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderASP.Models;

namespace OrderASP.Models.Service
{
    interface ICategory
    {
        /// <summary>
        /// Get all the categories
        /// </summary>
        /// <returns>List<Category></returns>
        List<Category> GetAll();
        /// <summary>
        /// Save a new category
        /// </summary>
        /// <param name="category">Category</param>
        void Save(Category category);
        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="category">Category</param>
        void Update(Category category);
        /// <summary>
        /// Get an identity
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Category</returns>
        Category GetEntity(int id);
        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="id">int</param>
        bool Delete(int id);
        /// <summary>
        /// Get categories by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>List<Category></returns>
        List<Category> GetByName(string name);
    }
}
