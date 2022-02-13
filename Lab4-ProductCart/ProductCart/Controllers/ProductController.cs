using ProductCart.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProductCart.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            CproductsEntities db = new CproductsEntities();
            var data = db.Products.ToList();
            return View(data);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View(new Product());
        }

        /*public ActionResult Show()
        {
            return View();
        }*/

        [HttpPost]

        public ActionResult Create(Product p)
        {
            if(ModelState.IsValid)
            {
                CproductsEntities db = new CproductsEntities();
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Cart(int Id)
        {
            CproductsEntities db = new CproductsEntities();

             var filteredProduct = (from p in db.Products
                                    where p.Id == Id
                                    select p).FirstOrDefault();
            //Session["order"] = Id;

            if(Session["cart"] == null)
            {
                List<Product> products = new List<Product>();
                products.Add(filteredProduct);
                string json = new JavaScriptSerializer().Serialize(filteredProduct);
                Session["cart"] = json.ToString();
            }
            else
            {
                string json = Session["cart"].ToString();
                var dec = new JavaScriptSerializer().Deserialize<List<Product>>(json);
                dec.Add(filteredProduct);
                var productList = new JavaScriptSerializer().Serialize(dec);
                Session["cart"] = productList.ToString();
            }

            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {
            if (Session["cart"] == null)
            {
                List<Product> dec = new List<Product>();
                return View(dec);
            }
            else
            {
                string json = Session["cart"].ToString();
                var dec = new JavaScriptSerializer().Deserialize<List<Product>>(json);
                return View(dec);
            }
        }

        public ActionResult Checkout(int Id)
        {
            
            return View();
        }
    }
}