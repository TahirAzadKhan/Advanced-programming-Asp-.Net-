using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Lab_Task___CRUD.Models;
using Lab_Task___CRUD.Models.Entity;
using System.Windows;
using System.Web.Script.Serialization;

namespace Lab_Task___CRUD.Controllers
{
    public class ProductController : Controller
    {
        // GET
        // : Product
        Database db = new Database();
        
        
        public ActionResult List()
        {
            
            var products = db.Products.GetAll();
            return View(products);
        }
        [HttpGet]

        public ActionResult Create()
        {
            Product p = new Product();
            return View(p);
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {

            if (ModelState.IsValid)
            {
                
                db.Products.Create(p);

                Response.Write("<script>alert('Data inserted successfully')</script>");
                return RedirectToAction("List");
            }
            return View(p);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var p=db.Products.GetProduct(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Product p) { 

            if (ModelState.IsValid)
                {
           
            db.Products.Create(p);
            return RedirectToAction("List");
            }
            return View(p);
        }
        public ActionResult Delete(int id)
        {

            db.Products.Delete(id);
            return RedirectToAction("List");
        }
       
        public ActionResult Cart(int id)
        {
            List<Product> cartProducts = null;
            Database db = new Database();

            var SoloProduct = db.Products.GetProduct(id);
            if (Session["cart"] == null)
            {
                cartProducts = new List<Product>();

                cartProducts.Add(SoloProduct);
                string cart = new JavaScriptSerializer().Serialize(cartProducts);
                Session["cart"] = cart;
                
            }
            else
            {
                var previousCart = Session["cart"].ToString();
                cartProducts = new JavaScriptSerializer().Deserialize<List<Product>>(previousCart);
                cartProducts.Add(SoloProduct);
                string cart = new JavaScriptSerializer().Serialize(cartProducts);
                Session["cart"] = cart;
               
            }
            return View(cartProducts);

        }
        




    }
}