using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewFashion.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; private set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; private set; }

        public bool IsRead { get; private set; }

        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        protected UserNotification()//οταν πειράζω τον ctor πρέπει να φτιάξω και τον default σε protected για το Entity Framework
        {
        }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (notification == null)
            {
                throw new ArgumentNullException("notification");
            }

            User = user;
            Notification = notification;
            IsRead = false;
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}