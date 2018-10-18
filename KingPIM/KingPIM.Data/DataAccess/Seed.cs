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
                    Id = 1,
                    Name = "Sport",
                    Subcategories = SportSubCategoryList
                };
                
                // New subcategory
                var Floorball = new Subcategory
                {
                    Id = 1,
                    Name = "Innebandy",
                    Category = Sport,
                    CategoryId = 1,
                    Products = FloorballProductList,
                    AttributeGroups = FloorballClubAttributeGroup
                };
                // Need to add all subcategories to the list
                SportSubCategoryList.Add(Floorball);
                
                // Floorball product
                var FloorballClub = new Product
                {
                    Id = 1,
                    Name = "Innebandy klubba",
                    Description = "Grundverktyget för att spela innebandy",
                    Price = 199.50,
                    Subcategory = Floorball,
                    SubcategoryId = 1
                };
                FloorballProductList.Add(FloorballClub);

                // Floorball club attribute
                var Blade = new AttributeGroup
                {
                    Id = 1,
                    Name = "Blad",
                    Description = "Bladet på innebandyklubban",
                    ProductAttributes = FloorballClubBladeProductAttribute
                };
                FloorballClubAttributeGroup.Add(Blade);

                // Blade attribute values
                var BladeColor = new ProductAttribute
                {
                    Id = 1,
                    Name = "Färg",
                    Description = "Blå",
                    AttributeGroup = Blade,
                    AttributeGroupId = 1,
                };
                FloorballClubBladeProductAttribute.Add(BladeColor);



            }
            
        }

    }
}
