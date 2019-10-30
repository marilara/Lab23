using Lab23Breakout.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab23Breakout.Controllers
{
    public class ShopController : Controller
    {
        ShopContext db = new ShopContext();

        public IActionResult Index()
        {
            List<Products> products = db.Products.ToList();

            return View(products);
        }

        public IActionResult Buy(int id)
        {
            Products p = db.Products.Find(id);

            if (p != null)
            {
                return View(p);
            }
            else
            {
                return RedirectToAction("Index", "Shop");
            }
        }

        public IActionResult Receipt(int id)
        {
            Products p = db.Products.Find(id);
            User u = db.User.Find(TempData["User"]);

            if (p.Price <= u.Funds)
            {
                ViewBag.UserFunds = u.Funds;
                ViewBag.ItemPrice = p.Price;
                ViewBag.NewBalance = u.Funds - p.Price;
                return View(p);
            }
            else
            {
                ViewBag.Error = "You did not have sufficient funds to purchase that item!";
                return View();
            }
        }
    }
}
