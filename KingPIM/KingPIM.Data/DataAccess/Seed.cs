using KingPIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPIM.Data
{
    public static class Seed
    {
        public static void FillIfEmpty(ApplicationDbContext ctx)
        {
            // Checks if theres any categories and if there isnt it adds everything
            if (!ctx.Categorys.Any())
            {

                
                // List of subcategories
                var SportSubCategoryList = new List<Subcategory>();
                // List of products
                var FloorballProductList = new List<Product>();
                // List of AttributeGroups
                var FloorballClubAttributeGroup = new List<AttributeGroup>();
                // List of Product attributes
                var FloorballClubBladeProductAttribute = new List<ProductAttribute>();

                // Category
                var Sport = new Category
                {
                    Name = "Sport",
                    AddedDate = DateTime.Now.Date,
                    Subcategories = SportSubCategoryList
                };
                
                // New subcategory
                var Floorball = new Subcategory
                {
                    Name = "Innebandy",
                    Category = Sport,
                    Products = FloorballProductList,
                    AttributeGroups = FloorballClubAttributeGroup
                };
                // Need to add all subcategories to the list
                SportSubCategoryList.Add(Floorball);
                
                // Floorball product
                var FloorballClub = new Product
                {
                    Name = "Innebandy klubba",
                    Description = "Grundverktyget för att spela innebandy",
                    Price = 199.50,
                    Subcategory = Floorball,
                };
                FloorballProductList.Add(FloorballClub);

                // Floorball club attribute
                var Blade = new AttributeGroup
                {
                    Name = "Blad",
                    Description = "Bladet på innebandyklubban",
                    ProductAttributes = FloorballClubBladeProductAttribute
                };
                FloorballClubAttributeGroup.Add(Blade);

                // Blade attribute values
                var BladeColor = new ProductAttribute
                {
                    Name = "Färg",
                    Description = "Blå",
                    AttributeGroup = Blade,
                };
                FloorballClubBladeProductAttribute.Add(BladeColor);

                ctx.SaveChanges();

            }
            
        }

    }
}
