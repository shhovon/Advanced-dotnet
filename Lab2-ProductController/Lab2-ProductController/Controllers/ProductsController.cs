using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2_ProductController.Models;

namespace Lab2_ProductController.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Home()
        {
            List<Products> products = new List<Products>();
            for (int i = 0; i < 10; i++)
            {
                var p = new Products()
                {
                    Id = i + 1,
                    Name = "Product " + (i + 1)
                };
                products.Add(p);
            }
            return View(products);
        }
    }
}