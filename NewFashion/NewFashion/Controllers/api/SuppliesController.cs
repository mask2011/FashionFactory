using NewFashion.DTOs;
using NewFashion.Models;
using System.Linq;
using System.Web.Http;



namespace NewFashion.Controllers.api
{
    [Authorize(Roles = "Admin")]
    public class SuppliesController : ApiController
    {
        private ApplicationDbContext db;

        public SuppliesController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult ChangeSelect(SelectDto dto)
        {
            var selected = db.SupplierOffers
                .Where(o => o.Id == dto.OfferId)
                .Single();

            selected.IsSelected = true;

            var sumSupplies = db.FactorySumSupplies.SingleOrDefault();
            sumSupplies.Buttons += selected.Buttons;
            sumSupplies.Cloth += selected.Cloth;
            sumSupplies.Stickers += selected.Stickers;
            sumSupplies.Thread += selected.Thread;
            sumSupplies.Zipper += selected.Zipper;

            db.SaveChanges();

            return Ok();
        }
    }
}
