using NewFashion.Models;
using NewFashion.Models.Enums;
using NewFashion.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace NewFashion.Controllers
{
    public class SaleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = "Seller")]
        public JsonResult IsProductInStock(int quantity, string productId)
        {
            var checkStock = _context.Products.Any(p => p.ProductId == productId && p.StoreQuantity >= quantity);

            var availableQuantity = _context.Products.Where(p => p.ProductId == productId).SingleOrDefault().StoreQuantity;

            return Json(new { checkStock, availableQuantity }, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public void DeleteItemFromSale(SalesFormViewModel viewModel)
        {
            var itemToDelete = _context.Sales
                .Where(s => s.InvoiceId == viewModel.InvoiceId && s.ProductId == viewModel.ProductId)
                .SingleOrDefault();

            if (itemToDelete == null)
                HttpNotFound();

            var fixProductStock = _context.Products.Single(p => p.ProductId == viewModel.ProductId);

            fixProductStock.StoreQuantity += itemToDelete.Quantity;

            _context.Sales.Remove(itemToDelete);
            _context.SaveChanges();
        }

        [Authorize(Roles = "Seller")]
        public JsonResult GetProducts(ProductType productType = 0)
        {
            var products = new List<string>();

            products = _context.Products.Where(p => p.Type == productType).Select(p => p.ProductId).ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Seller")]
        public JsonResult SaveOrder(SalesFormViewModel viewModel)
        {
            bool status = false;

            Sale sale = new Sale()
            {
                InvoiceId = viewModel.InvoiceId,
                DateTime = viewModel.DateTime,
                ProductId = viewModel.ProductId,
                Quantity = viewModel.Quantity
            };

            var reduceProductStock = _context.Products.Single(p => p.ProductId == viewModel.ProductId);

            reduceProductStock.StoreQuantity -= sale.Quantity;

            var isValidModel = TryUpdateModel(sale);
            if (isValidModel)
            {
                _context.Sales.Add(sale);
                _context.SaveChanges();
            }

            status = true;

            return new JsonResult { Data = new { status = status } };
        }

        [Authorize(Roles = "Admin, Seller")]
        public ActionResult Index(int? page)
        {
            const int pageSize = 5;
            int pageNumber = (page ?? 1);

            var allsales = _context.Sales
                .GroupBy(s => s.InvoiceId)
                .Select(s => s.FirstOrDefault())
                .OrderBy(s => s.DateTime)
                .ToPagedList(pageNumber, pageSize);

            return View("AllSales", allsales);
        }

        [Authorize(Roles = "Seller")]
        public ActionResult Create()
        {
            var invoiceIdCount = _context.Sales.ToList().LastOrDefault().Id;

            var viewModel = new SalesFormViewModel
            {
                InvoiceId = invoiceIdCount + 1,
                DateTime = DateTime.Now
            };

            return View("Create3", viewModel);
        }

        [Authorize(Roles = "Admin, Seller")]
        public ActionResult ShowInvoice(int? id)
        {
            var sale = _context.Sales
                .Include(p => p.Product)
                .Where(p => p.InvoiceId == id)
                .ToList();

            if (sale.Count == 0)
                return HttpNotFound();

            decimal totalPriceCalculation = 0;

            foreach (var product in sale)
            {
                totalPriceCalculation += product.Product.Price * product.Quantity;
            }

            var viewModel = new InvoiceViewModel
            {
                InvoiceId = sale.FirstOrDefault().InvoiceId,
                DateTime = sale.FirstOrDefault().DateTime,
                ProductSaleViewModels = new List<ProductSaleViewModel>(),
                TotalPrice = totalPriceCalculation
            };

            foreach (var product in sale)
            {
                var saleProduct = new ProductSaleViewModel
                {
                    Color = product.Product.Color,
                    ProductId = product.Product.ProductId,
                    Type = product.Product.Type,
                    Gender = product.Product.Gender,
                    Size = product.Product.Size,
                    Quantity = product.Quantity,
                    Price = product.Product.Price
                };

                viewModel.ProductSaleViewModels.Add(saleProduct);
            }

            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
