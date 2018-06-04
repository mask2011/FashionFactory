using Microsoft.AspNet.Identity.EntityFramework;
using NewFashion.Models.Facilities;
using System.Data.Entity;

namespace NewFashion.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SupplierOffer> SupplierOffers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Buying> Buyings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<FactorySumSupplies> FactorySumSupplies { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserNotification>()
               .HasRequired(n => n.User)
               .WithMany(u => u.UserNotifications)
               .WillCascadeOnDelete(false);
        }
    }
}