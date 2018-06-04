using NewFashion.Models;
using NewFashion.Models.Facilities;
using NewFashion.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace NewFashion.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FactoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Factories
        public ActionResult Index()
        {
            return View(db.Factories.ToList());
        }

        // GET: Factories/Employees
        public ActionResult Employees()
        {
            var allWorkers = db.Workers.OrderBy(w => w.LastName).ToList();

            var viewModel = new List<FactoryEmployees>();

            string wLocation = "";

            foreach (var w in allWorkers)
            {
                if (w.FactoryID != null) { wLocation = "Factory"; }
                if (w.WarehouseID != null) { wLocation = "Warehouse"; }

                viewModel.Add(new FactoryEmployees
                {
                    WorkerID = w.WorkerID,
                    FirstName = w.FirstName,
                    LastName = w.LastName,
                    Location = wLocation

                });
            }

            return View(viewModel);
        }

        // GET: Factories/Employees/Create
        public ActionResult CreateEmployees()
        {
            return View("CreateEmployees");
        }

        // POST: Factories/Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployees([Bind(Include = "WorkerID,FirstName,LastName,FactoryID,WarehouseID")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Employees");
            }

            return View("Employees", worker);
        }

        // GET: Factories/Employees/Edit/5
        public ActionResult EditEmployees(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View("EditEmployees", worker);
        }

        // POST: Factories/Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployees([Bind(Include = "WorkerID,FirstName,LastName,FactoryID,WarehouseID")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Employees");
            }

            return View("EditEmployees", worker);
        }

        // GET: Factories/Employees/Details/5
        public ActionResult DetailsEmployees(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Worker worker = db.Workers.Find(id);

            if (worker == null)
            {
                return HttpNotFound();
            }

            return View("DetailsEmployees", worker);
        }

        // GET: Factories/Employees/Delete/5
        public ActionResult DeleteEmployees(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Worker worker = db.Workers.Find(id);

            if (worker == null)
            {
                return HttpNotFound();
            }

            return View("DeleteEmployees", worker);
        }

        // POST: Factories/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployeesConfirmed(string id)
        {
            Worker worker = db.Workers.Find(id);

            db.Workers.Remove(worker);
            db.SaveChanges();

            return RedirectToAction("Employees");
        }

        // GET: Factories/Supplies
        public ActionResult Supplies()
        {
            var supplies = db.FactorySumSupplies.ToList();

            var viewModel = new List<ViewModels.FactorySumSupplies>();

            foreach (var s in supplies)
            {
                viewModel.Add(new ViewModels.FactorySumSupplies
                {
                    Buttons = s.Buttons,
                    Cloth = s.Cloth,
                    Stickers = s.Stickers,
                    Thread = s.Thread,
                    Zipper = s.Zipper
                });
            }

            return View(viewModel);
        }

        // GET: Factories/Production
        public ActionResult Production()
        {
            return View();
        }

        // POST: Factories/Production
        [HttpPost, ActionName("Production")]
        public ActionResult PostProduction()
        {
            Factory.AutoProduction();

            ViewBag.Message = Factory.Message;

            return View();
        }

        // GET: Factories/CustomProduction
        [ActionName("CustomProduction")]
        public ActionResult GetCustomProduction()
        {
            var viewModel = new FactoryProduction
            {
                Message = ""
            };

            return View("CustomProduction", viewModel);
        }

        // POST: Factories/CustomProduction
        [HttpPost, ActionName("CustomProduction")]
        [ValidateAntiForgeryToken]
        public ActionResult PostCustomProduction([Bind(Include = "Quantity,Type,Gender,Size,Color")] FactoryProduction viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomProduction", viewModel);
            }

            Factory.ClothesProduction(viewModel);

            return View("CustomProduction", viewModel);
        }

        // GET: Factories/Stock
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

        // GET: Factories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Factory factory = db.Factories.Find(id);

            if (factory == null)
            {
                return HttpNotFound();
            }

            return View(factory);
        }

        // GET: Factories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FactoryID,ClothesDailyProdutionLog,TrousersDailyProdutionLog")] Factory factory)
        {
            if (ModelState.IsValid)
            {
                db.Factories.Add(factory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factory);
        }

        // GET: Factories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Factory factory = db.Factories.Find(id);

            if (factory == null)
            {
                return HttpNotFound();
            }

            return View(factory);
        }

        // POST: Factories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FactoryID,ClothesDailyProdutionLog,TrousersDailyProdutionLog")] Factory factory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factory).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(factory);
        }

        // GET: Factories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Factory factory = db.Factories.Find(id);

            if (factory == null)
            {
                return HttpNotFound();
            }

            return View(factory);
        }

        // POST: Factories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factory factory = db.Factories.Find(id);

            db.Factories.Remove(factory);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
