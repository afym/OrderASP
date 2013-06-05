using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderASP.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public bool InStock { set; get; }
        public Category Category { set; get; }
    }
}