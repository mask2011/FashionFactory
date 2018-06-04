using NewFashion.Models;
using System.Linq;
using System.Web.Mvc;

namespace NewFashion.Controllers
{
    public class ApplicationUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var role = db.Roles.SingleOrDefault(m => m.Name == "Seller");
            var sellers = db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id));

            return View(sellers.ToList());
        }
    }
}