using NewFashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NewFashion.Controllers
{
    [Authorize(Roles = "Admin, Seller")]
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext db;

        public StoreController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Stock(string searchString, string serialNumber)
        {
            var serialNumberList = new List<string>();

            var allserialNumbers = from g in db.Products
                                   orderby g.ProductId
                                   select g.ProductId;

            serialNumberList.AddRange(allserialNumbers.Distinct());
            ViewBag.serialNumber = new SelectList(serialNumberList);

            var stockPoduct = from s in db.Products
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                stockPoduct = stockPoduct.Where(s => (s.Type).ToString().Contains(searchString));
            }

            if (!String.IsNullOrEmpty(serialNumber))
            {
                stockPoduct = stockPoduct.Where(s => s.ProductId == serialNumber);
            }

            return View(stockPoduct);
        }
    }
}