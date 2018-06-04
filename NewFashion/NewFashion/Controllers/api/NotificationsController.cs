using Microsoft.AspNet.Identity;
using NewFashion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;



namespace NewFashion.Controllers.api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext db;

        public NotificationsController()
        {
            db = new ApplicationDbContext();
        }

        [HttpGet]
        [ActionName("GetNewNotifications")]
        public List<Notification> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = db.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .ToList();

            return notifications;
        }

        [HttpPost]
        [ActionName("MarkAsRead")]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = db.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();

            notifications.ForEach(n => n.Read());

            db.SaveChanges();

            return Ok();
        }
    }
}
