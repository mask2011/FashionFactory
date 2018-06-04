using NewFashion.Models.Enums;
using NewFashion.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NewFashion.Models.Facilities
{
    public class Factory
    {
        public int FactoryID { get; set; }

        [Display(Name = "T-Shirts Daily Production Log")]
        public string ClothesDailyProdutionLog { get; set; }

        [Display(Name = "Trousers Daily Production Log")]
        public string TrousersDailyProdutionLog { get; set; }

        public static string Message = "";

        public static void AutoProduction()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var factory = db.Factories.Single();

            var clothesSupplies = db.FactorySumSupplies.SingleOrDefault();

            int requiredButtonQuantityForT_Shirts = 300 * 3;
            decimal requiredClothQuantityForT_Shirts = Convert.ToDecimal(300 * 1.5);
            int requiredStickerQuantityForT_Shirts = 300 * 2;
            decimal requiredThreadQuantityForT_Shirts = Convert.ToDecimal(300 * 1.4);


            if (clothesSupplies.Buttons > requiredButtonQuantityForT_Shirts
                && clothesSupplies.Cloth > requiredClothQuantityForT_Shirts
                && clothesSupplies.Stickers > requiredStickerQuantityForT_Shirts
                && clothesSupplies.Thread > requiredThreadQuantityForT_Shirts)
            {
                clothesSupplies.Buttons -= requiredButtonQuantityForT_Shirts;
                clothesSupplies.Cloth -= requiredClothQuantityForT_Shirts;
                clothesSupplies.Stickers -= requiredStickerQuantityForT_Shirts;
                clothesSupplies.Thread -= requiredThreadQuantityForT_Shirts;

                factory.ClothesDailyProdutionLog = 300.ToString() + " Date: " + DateTime.Now.ToString("dd/MM/yyyy");

                var tshirts = db.Products.Where(p => p.Type == ProductType.T_Shirt).ToList();

                foreach (var t in tshirts)
                {
                    t.WarehouseQuantity += 3;
                    t.StoreQuantity += 3;
                }
            }

            int requiredButtonQuantityForTrousers = 300 * 8;
            decimal requiredClothquantityForTrousers = Convert.ToDecimal(300 * 1.4);
            int requiredStickerQuantityForTrousers = 300 * 2;
            decimal requiredThreadQuantityForTrousers = Convert.ToDecimal(300 * 1.4);
            decimal requiredZippersQuantityForTrousers = Convert.ToDecimal(300 * 1);

            if (clothesSupplies.Buttons > requiredButtonQuantityForTrousers
                && clothesSupplies.Cloth > requiredClothquantityForTrousers
                && clothesSupplies.Stickers > requiredStickerQuantityForTrousers
                && clothesSupplies.Thread > requiredThreadQuantityForTrousers
                && clothesSupplies.Zipper > requiredZippersQuantityForTrousers)
            {
                clothesSupplies.Buttons -= requiredButtonQuantityForTrousers;
                clothesSupplies.Cloth -= requiredClothquantityForTrousers;
                clothesSupplies.Stickers -= requiredStickerQuantityForTrousers;
                clothesSupplies.Thread -= requiredThreadQuantityForTrousers;
                clothesSupplies.Zipper -= requiredZippersQuantityForTrousers;

                factory.TrousersDailyProdutionLog = 300.ToString() + " Date: " + DateTime.Now.ToString("dd/MM/yyyy");

                var trousers = db.Products.Where(p => p.Type == ProductType.Trousers).ToList();

                foreach (var t in trousers)
                {
                    if (t.Color == Color.Black)
                    {
                        t.WarehouseQuantity += 8;
                        t.StoreQuantity += 8;
                    }
                    else
                    {
                        t.WarehouseQuantity += 7;
                        t.StoreQuantity += 7;
                    }
                }

                db.SaveChanges();

                Message = "Daily Production Authorized!";
            }
            else
            {
                Message = "Not enough Supplies!";

            }
        }

        public static void ClothesProduction(FactoryProduction viewModel)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var factory = db.Factories.Single();

            var clothesSupplies = db.FactorySumSupplies.SingleOrDefault();

            switch (viewModel.Type)
            {
                case ProductType.T_Shirt:

                    decimal requiredClothquantityForT_Shirts = Convert.ToDecimal(viewModel.Quantity * 1.5);
                    int requiredButtonQuantityForT_Shirts = viewModel.Quantity * 3;
                    int requiredStickerQuantityForT_Shirts = viewModel.Quantity * 2;
                    decimal requiredThreadQuantityForT_Shirts = Convert.ToDecimal(viewModel.Quantity * 1.2);

                    if (clothesSupplies.Cloth > requiredClothquantityForT_Shirts
                        && clothesSupplies.Buttons > requiredButtonQuantityForT_Shirts
                        && clothesSupplies.Stickers > requiredStickerQuantityForT_Shirts
                        && clothesSupplies.Thread > requiredThreadQuantityForT_Shirts)
                    {
                        clothesSupplies.Cloth = clothesSupplies.Cloth - requiredClothquantityForT_Shirts;
                        clothesSupplies.Buttons = clothesSupplies.Buttons - requiredButtonQuantityForT_Shirts;
                        clothesSupplies.Stickers -= requiredStickerQuantityForT_Shirts;
                        clothesSupplies.Thread -= requiredThreadQuantityForT_Shirts;

                        factory.ClothesDailyProdutionLog = viewModel.Quantity.ToString()
                            + " Date: " + DateTime.Now.ToString("dd/MM/yyyy");

                        var product = db.Products
                            .Where(p => p.Color == viewModel.Color
                            && p.Gender == viewModel.Gender
                            && p.Size == viewModel.Size
                            && p.Type == viewModel.Type).Single();

                        product.WarehouseQuantity += viewModel.Quantity;

                        db.SaveChanges();

                        viewModel.Message = "Your Order Sent to Production!";
                    }
                    else
                    {
                        viewModel.Message = "Not enough Supplies to Produce this Order!";
                    }

                    break;

                case ProductType.Trousers:

                    decimal requiredClothquantityForTrousers = Convert.ToDecimal(viewModel.Quantity * 1.4);
                    int requiredButtonQuantityForTrousers = viewModel.Quantity * 8;
                    int requiredStickerQuantityForTrousers = viewModel.Quantity * 2;
                    decimal requiredThreadQuantityForTrousers = Convert.ToDecimal(viewModel.Quantity * 1.4);
                    decimal requiredZippersQuantityForTrousers = Convert.ToDecimal(viewModel.Quantity * 1);

                    if (clothesSupplies.Cloth > requiredClothquantityForTrousers
                        && clothesSupplies.Buttons > requiredButtonQuantityForTrousers
                        && clothesSupplies.Thread > requiredThreadQuantityForTrousers
                        && clothesSupplies.Stickers > requiredStickerQuantityForTrousers
                        && clothesSupplies.Zipper > requiredZippersQuantityForTrousers)
                    {
                        clothesSupplies.Cloth = clothesSupplies.Cloth - requiredClothquantityForTrousers;
                        clothesSupplies.Buttons = clothesSupplies.Buttons - requiredButtonQuantityForTrousers;
                        clothesSupplies.Thread -= requiredThreadQuantityForTrousers;
                        clothesSupplies.Stickers -= requiredStickerQuantityForTrousers;
                        clothesSupplies.Zipper -= requiredZippersQuantityForTrousers;

                        factory.TrousersDailyProdutionLog = viewModel.Quantity.ToString()
                            + " Date: " + DateTime.Now.ToString("dd/MM/yyyy");

                        var product = db.Products
                            .Where(p => p.Color == viewModel.Color
                            && p.Gender == viewModel.Gender
                            && p.Size == viewModel.Size
                            && p.Type == viewModel.Type).Single();

                        product.WarehouseQuantity += viewModel.Quantity;

                        db.SaveChanges();

                        viewModel.Message = "Your Order Sent to Production!";
                    }
                    else
                    {
                        viewModel.Message = "Not enough Supplies to Produce this Order!";
                    }

                    break;

                default:

                    break;
            }
        }

        public static string GenerateRandom()
        {
            Random random = new Random();

            int number = random.Next(999, 9999);

            return number.ToString();
        }
    }
}