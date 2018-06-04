namespace NewFashion.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using NewFashion.Models;
    using NewFashion.Models.Enums;
    using NewFashion.Models.Facilities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewFashion.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NewFashion.Models.ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(r => r.Name,
                 new IdentityRole { Name = "Admin" },
                 new IdentityRole { Name = "Seller" },
                 new IdentityRole { Name = "Supplier" }
             );

            context.SaveChanges();

            var buildings = new List<Building>
            {
                new Building {BuildingType = BuildingType.Factory, Address = "Dia 25", City = "Athens"},
                new Building {BuildingType = BuildingType.WareHouse, Address = "Kronou 33", City = "Athens" },
                new Building {BuildingType = BuildingType.Store, Address = "Ouranou 48", City = "Athens" },
                new Building {BuildingType = BuildingType.Office, Address = "Posidonos 12", City = "Athens"}
            };

            buildings.ForEach(b => context.Buildings.AddOrUpdate(u => u.Address, b));
            context.SaveChanges();

            var factories = new List<Factory>
            {
                 new Factory{ FactoryID = 1 }
            };

            factories.ForEach(f => context.Factories.AddOrUpdate(p => p.FactoryID, f));
            context.SaveChanges();

            var stores = new List<Store>
            {
                new Store { StoreID = 1, ProductCapacity = 2000 }
            };

            stores.ForEach(s => context.Stores.AddOrUpdate(p => p.StoreID, s));
            context.SaveChanges();

            var offices = new List<Office>
            {
                new Office { Address = "Posidonos 12", City = "Athens" }
            };

            offices.ForEach(o => context.Offices.AddOrUpdate(p => p.Address, o));
            context.SaveChanges();

            var workers = new List<Worker>
            {
                new Worker {FirstName = "Xristos", LastName = "Maskinis",
                            FactoryID = (buildings.Single(b => b.BuildingType == BuildingType.Factory).BuildingId)},
                new Worker {FirstName = "Periklis", LastName = "Begnis",
                            WarehouseID = (buildings.Single(b => b.BuildingType == BuildingType.WareHouse).BuildingId)},
                new Worker {FirstName = "George", LastName = "Satras",
                            FactoryID = (buildings.Single(b => b.BuildingType == BuildingType.Factory).BuildingId)}
            };

            workers.ForEach(s => context.Workers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {ProductId = "F100XS0", Price = 35, Gender = Gender.Female,
                    Size = Size.XSmall, Type = ProductType.T_Shirt, Color = Color.White, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100XS1", Price = 35, Gender = Gender.Female,
                    Size = Size.XSmall, Type = ProductType.T_Shirt, Color = Color.Black, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100XS2", Price = 35, Gender = Gender.Female,
                    Size = Size.XSmall, Type = ProductType.T_Shirt, Color = Color.Blue, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100XS3", Price = 35, Gender = Gender.Female,
                    Size = Size.XSmall, Type = ProductType.T_Shirt, Color = Color.Red, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100XS4", Price = 35, Gender = Gender.Female,
                    Size = Size.XSmall, Type = ProductType.T_Shirt, Color = Color.Green, StoreQuantity = 3, WarehouseQuantity = 3},

                new Product {ProductId = "F100S0", Price = 35, Gender = Gender.Female,
                    Size = Size.Small, Type = ProductType.T_Shirt, Color = Color.White, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100S1", Price = 35, Gender = Gender.Female,
                    Size = Size.Small, Type = ProductType.T_Shirt, Color = Color.Black, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100S2", Price = 35, Gender = Gender.Female,
                    Size = Size.Small, Type = ProductType.T_Shirt, Color = Color.Blue, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100S3", Price = 35, Gender = Gender.Female,
                    Size = Size.Small, Type = ProductType.T_Shirt, Color = Color.Red, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100S4", Price = 35, Gender = Gender.Female,
                    Size = Size.Small, Type = ProductType.T_Shirt, Color = Color.Green, StoreQuantity = 3, WarehouseQuantity = 3},

                new Product {ProductId = "F100M0", Price = 35, Gender = Gender.Female,
                    Size = Size.Medium, Type = ProductType.T_Shirt, Color = Color.White, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100M1", Price = 35, Gender = Gender.Female,
                    Size = Size.Medium, Type = ProductType.T_Shirt, Color = Color.Black, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100M2", Price = 35, Gender = Gender.Female,
                    Size = Size.Medium, Type = ProductType.T_Shirt, Color = Color.Blue, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100M3", Price = 35, Gender = Gender.Female,
                    Size = Size.Medium, Type = ProductType.T_Shirt, Color = Color.Red, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100M4", Price = 35, Gender = Gender.Female,
                    Size = Size.Medium, Type = ProductType.T_Shirt, Color = Color.Green, StoreQuantity = 3, WarehouseQuantity = 3},

                new Product {ProductId = "F100L0", Price = 35, Gender = Gender.Female,
                    Size = Size.Large, Type = ProductType.T_Shirt, Color = Color.White, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100L1", Price = 35, Gender = Gender.Female,
                    Size = Size.Large, Type = ProductType.T_Shirt, Color = Color.Black, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100L2", Price = 35, Gender = Gender.Female,
                    Size = Size.Large, Type = ProductType.T_Shirt, Color = Color.Blue, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100L3", Price = 35, Gender = Gender.Female,
                    Size = Size.Large, Type = ProductType.T_Shirt, Color = Color.Red, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100L4", Price = 35, Gender = Gender.Female,
                    Size = Size.Large, Type = ProductType.T_Shirt, Color = Color.Green, StoreQuantity = 3, WarehouseQuantity = 3},

                new Product {ProductId = "F100XL0", Price = 35, Gender = Gender.Female,
                    Size = Size.XL, Type = ProductType.T_Shirt, Color = Color.White, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100XL1", Price = 35, Gender = Gender.Female,
                    Size = Size.XL, Type = ProductType.T_Shirt, Color = Color.Black, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100XL2", Price = 35, Gender = Gender.Female,
                    Size = Size.XL, Type = ProductType.T_Shirt, Color = Color.Blue, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100XL3", Price = 35, Gender = Gender.Female,
                    Size = Size.XL, Type = ProductType.T_Shirt, Color = Color.Red, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "F100XL4", Price = 35, Gender = Gender.Female,
                    Size = Size.XL, Type = ProductType.T_Shirt, Color = Color.Green, StoreQuantity = 3, WarehouseQuantity = 3},


                new Product {ProductId = "M200S0", Price = 30, Gender = Gender.Male,
                    Size = Size.Small, Type = ProductType.T_Shirt, Color = Color.White, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200S1", Price = 30, Gender = Gender.Male,
                    Size = Size.Small, Type = ProductType.T_Shirt, Color = Color.Black, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200S2", Price = 30, Gender = Gender.Male,
                    Size = Size.Small, Type = ProductType.T_Shirt, Color = Color.Blue, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200S3", Price = 30, Gender = Gender.Male,
                    Size = Size.Small, Type = ProductType.T_Shirt, Color = Color.Red, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200S4", Price = 30, Gender = Gender.Male,
                    Size = Size.Small, Type = ProductType.T_Shirt, Color = Color.Green, StoreQuantity = 3, WarehouseQuantity = 3},

                new Product {ProductId = "M200M0", Price = 30, Gender = Gender.Male,
                    Size = Size.Medium, Type = ProductType.T_Shirt, Color = Color.White, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200M1", Price = 30, Gender = Gender.Male,
                    Size = Size.Medium, Type = ProductType.T_Shirt, Color = Color.Black, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200M2", Price = 30, Gender = Gender.Male,
                    Size = Size.Medium, Type = ProductType.T_Shirt, Color = Color.Blue, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200M3", Price = 30, Gender = Gender.Male,
                    Size = Size.Medium, Type = ProductType.T_Shirt, Color = Color.Red, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200M4", Price = 30, Gender = Gender.Male,
                    Size = Size.Medium, Type = ProductType.T_Shirt, Color = Color.Green, StoreQuantity = 3, WarehouseQuantity = 3},

                new Product {ProductId = "M200L0", Price = 30, Gender = Gender.Male,
                    Size = Size.Large, Type = ProductType.T_Shirt, Color = Color.White, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200L1", Price = 30, Gender = Gender.Male,
                    Size = Size.Large, Type = ProductType.T_Shirt, Color = Color.Black, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200L2", Price = 30, Gender = Gender.Male,
                    Size = Size.Large, Type = ProductType.T_Shirt, Color = Color.Blue, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200L3", Price = 30, Gender = Gender.Male,
                    Size = Size.Large, Type = ProductType.T_Shirt, Color = Color.Red, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200L4", Price = 30, Gender = Gender.Male,
                    Size = Size.Large, Type = ProductType.T_Shirt, Color = Color.Green, StoreQuantity = 3, WarehouseQuantity = 3},

                new Product {ProductId = "M200XL0", Price = 30, Gender = Gender.Male,
                    Size = Size.XL, Type = ProductType.T_Shirt, Color = Color.White, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200XL1", Price = 30, Gender = Gender.Male,
                    Size = Size.XL, Type = ProductType.T_Shirt, Color = Color.Black, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200XL2", Price = 30, Gender = Gender.Male,
                    Size = Size.XL, Type = ProductType.T_Shirt, Color = Color.Blue, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200XL3", Price = 30, Gender = Gender.Male,
                    Size = Size.XL, Type = ProductType.T_Shirt, Color = Color.Red, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200XL4", Price = 30, Gender = Gender.Male,
                    Size = Size.XL, Type = ProductType.T_Shirt, Color = Color.Green, StoreQuantity = 3, WarehouseQuantity = 3},

                new Product {ProductId = "M200XXL0", Price = 30, Gender = Gender.Male,
                    Size = Size.XXL, Type = ProductType.T_Shirt, Color = Color.White, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200XXL1", Price = 30, Gender = Gender.Male,
                    Size = Size.XXL, Type = ProductType.T_Shirt, Color = Color.Black, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200XXL2", Price = 30, Gender = Gender.Male,
                    Size = Size.XXL, Type = ProductType.T_Shirt, Color = Color.Blue, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200XXL3", Price = 30, Gender = Gender.Male,
                    Size = Size.XXL, Type = ProductType.T_Shirt, Color = Color.Red, StoreQuantity = 3, WarehouseQuantity = 3},
                new Product {ProductId = "M200XXL4", Price = 30, Gender = Gender.Male,
                    Size = Size.XXL, Type = ProductType.T_Shirt, Color = Color.Green, StoreQuantity = 3, WarehouseQuantity = 3},


                new Product {ProductId = "F777XS0", Price = 45, Gender = Gender.Female,
                    Size = Size.XSmall, Type = ProductType.Trousers, Color = Color.White, StoreQuantity = 7, WarehouseQuantity = 7},
                new Product {ProductId = "F777XS1", Price = 45, Gender = Gender.Female,
                    Size = Size.XSmall, Type = ProductType.Trousers, Color = Color.Black, StoreQuantity = 8, WarehouseQuantity = 8},

                new Product {ProductId = "F777S0", Price = 45, Gender = Gender.Female,
                    Size = Size.Small, Type = ProductType.Trousers, Color = Color.White, StoreQuantity = 7, WarehouseQuantity = 7},
                new Product {ProductId = "F777S1", Price = 45, Gender = Gender.Female,
                    Size = Size.Small, Type = ProductType.Trousers, Color = Color.Black, StoreQuantity = 8, WarehouseQuantity = 8},


                new Product {ProductId = "F777M0", Price = 45, Gender = Gender.Female,
                    Size = Size.Medium, Type = ProductType.Trousers, Color = Color.White, StoreQuantity = 7, WarehouseQuantity = 7},
                new Product {ProductId = "F777M1", Price = 45, Gender = Gender.Female,
                    Size = Size.Medium, Type = ProductType.Trousers, Color = Color.Black, StoreQuantity = 8, WarehouseQuantity = 8},

                new Product {ProductId = "F777L0", Price = 45, Gender = Gender.Female,
                    Size = Size.Large, Type = ProductType.Trousers, Color = Color.White, StoreQuantity = 7, WarehouseQuantity = 7},
                new Product {ProductId = "F777L1", Price = 45, Gender = Gender.Female,
                    Size = Size.Large, Type = ProductType.Trousers, Color = Color.Black, StoreQuantity = 8, WarehouseQuantity = 8},

                new Product {ProductId = "F777XL0", Price = 45, Gender = Gender.Female,
                    Size = Size.XL, Type = ProductType.Trousers, Color = Color.White, StoreQuantity = 7, WarehouseQuantity = 7},
                new Product {ProductId = "F777XL1", Price = 45, Gender = Gender.Female,
                    Size = Size.XL, Type = ProductType.Trousers, Color = Color.Black, StoreQuantity = 8, WarehouseQuantity = 8},


                new Product {ProductId = "M999S1", Price = 50, Gender = Gender.Male,
                    Size = Size.Small, Type = ProductType.Trousers, Color = Color.Black, StoreQuantity = 8, WarehouseQuantity = 8},
                new Product {ProductId = "M999S2", Price = 50, Gender = Gender.Male,
                    Size = Size.Small, Type = ProductType.Trousers, Color = Color.Blue, StoreQuantity = 7, WarehouseQuantity = 7},

                new Product {ProductId = "M999M1", Price = 50, Gender = Gender.Male,
                    Size = Size.Medium, Type = ProductType.Trousers, Color = Color.Black, StoreQuantity = 8, WarehouseQuantity = 8},
                new Product {ProductId = "M999M2", Price = 50, Gender = Gender.Male,
                    Size = Size.Medium, Type = ProductType.Trousers, Color = Color.Blue, StoreQuantity = 7, WarehouseQuantity = 7},

                new Product {ProductId = "M999L1", Price = 50, Gender = Gender.Male,
                    Size = Size.Large, Type = ProductType.Trousers, Color = Color.Black, StoreQuantity = 8, WarehouseQuantity = 8},
                new Product {ProductId = "M999L2", Price = 50, Gender = Gender.Male,
                    Size = Size.Large, Type = ProductType.Trousers, Color = Color.Blue, StoreQuantity = 7, WarehouseQuantity = 7},

                new Product {ProductId = "M999XL1", Price = 50, Gender = Gender.Male,
                    Size = Size.XL, Type = ProductType.Trousers, Color = Color.Black, StoreQuantity = 8, WarehouseQuantity = 8},
                new Product {ProductId = "M999XL2", Price = 50, Gender = Gender.Male,
                    Size = Size.XL, Type = ProductType.Trousers, Color = Color.Blue, StoreQuantity = 7, WarehouseQuantity = 7},

                new Product {ProductId = "M999XXL1", Price = 50, Gender = Gender.Male,
                    Size = Size.XXL, Type = ProductType.Trousers, Color = Color.Black, StoreQuantity = 8, WarehouseQuantity = 8},
                new Product {ProductId = "M999XXL2", Price = 50, Gender = Gender.Male,
                    Size = Size.XXL, Type = ProductType.Trousers, Color = Color.Blue, StoreQuantity = 7, WarehouseQuantity = 7}
            };

            products.ForEach(pr => context.Products.AddOrUpdate(p => p.ProductId, pr));
            context.SaveChanges();

            var sale = new Sale()
            {
                InvoiceId = 0,
                ProductId = "M999XXL2",
                Quantity = 1,
                DateTime = DateTime.Now
            };

            context.Sales.Add(sale);
            context.SaveChanges();

            var factorySumSupplies = new FactorySumSupplies()
            {
                Buttons = 0,
                Cloth = 0,
                Stickers = 0,
                Thread = 0,
                Zipper = 0
            };

            context.FactorySumSupplies.Add(factorySumSupplies);
            context.SaveChanges();
        }
    }
}
