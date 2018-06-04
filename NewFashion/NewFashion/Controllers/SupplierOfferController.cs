using Microsoft.AspNet.Identity;
using NewFashion.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace NewFashion.Controllers
{
    public class SupplierOfferController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        public ActionResult SelectedOffers()
        {
            var selectedOffers = db.SupplierOffers
                .Where(o => o.IsSelected == true)
                .ToList();

            return View(selectedOffers);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Suppliers()
        {
            var role = db.Roles.SingleOrDefault(m => m.Name == "Supplier");
            var suppliers = db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList();

            return View(suppliers);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SupplierInfo(string id)
        {
            List<ApplicationUser> SupplierInfo = db.Users.Where(c => c.Id == id).ToList();

            return View("SupplierInfo", SupplierInfo);
        }

        [Authorize(Roles = "Admin, Supplier")]
        public ActionResult AllOffers()
        {
            var suppliesOffers = db.SupplierOffers.Include(s => s.Supplier);

            if (User.IsInRole("Supplier"))
            {
                var userId = User.Identity.GetUserId();
                suppliesOffers = suppliesOffers.Where(o => o.SupplierID == userId);
            }

            return View(suppliesOffers.ToList());
        }

        [Authorize(Roles = "Supplier")]
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new SupplierOffer()
            {
                SupplierID = userId
            };

            return View(viewModel);
        }

        // POST: SuppliesOffer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Supplier")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cloth,PricePerMeter,Buttons,PricePerButton,Stickers,PricePerSticker,Thread,PricePerThread,Zipper,PricePerZipper,SupplierID")] SupplierOffer supplierOffer)
        {
            if (!ModelState.IsValid)
            {
                supplierOffer.SupplierID = User.Identity.GetUserId();
                return View(supplierOffer);
            }

            db.SupplierOffers.Add(supplierOffer);

            var role = db.Roles.SingleOrDefault(m => m.Name == "Admin");
            var usersToNotify = db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList();

            supplierOffer.Created(usersToNotify);
            db.SaveChanges();

            return RedirectToAction("Create");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SupplierOffer supplierOffer = db.SupplierOffers.Find(id);

            if (supplierOffer == null)
            {
                return HttpNotFound();
            }

            ViewBag.SupplierID = new SelectList(db.Users, "Id", "Name", supplierOffer.SupplierID);
            return View(supplierOffer);
        }

        // POST: SuppliesOffer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cloth,PricePerSqMeter,Buttons,PricePerButton,Stickers,PricePerSticker,Thread,PricePerThread,SupplierID")] SupplierOffer supplierOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierID = new SelectList(db.Users, "Id", "Name", supplierOffer.SupplierID);
            return View(supplierOffer);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SupplierOffer supplierOffer = db.SupplierOffers.Find(id);

            if (supplierOffer == null)
            {
                return HttpNotFound();
            }
            return View(supplierOffer);
        }

        // POST: SuppliesOffer/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplierOffer supplierOffer = db.SupplierOffers.Find(id);

            db.SupplierOffers.Remove(supplierOffer);
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