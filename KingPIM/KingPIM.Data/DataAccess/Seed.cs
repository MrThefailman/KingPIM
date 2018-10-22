using KingPIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPIM.Data
{
    public class Seed
    {
        public static void FillIfEmpty(ApplicationDbContext ctx)
        {
            // The list variables created for the Seed():
            var subCategoryList = new List<Subcategory>();
            var productList = new List<Product>();
            var attributeGroupList = new List<AttributeGroup>();
            var productAttributeList = new List<ProductAttribute>();
            var productAttributeValueList = new List<ProductAttributeValue>();
            
            var productAttribute = new ProductAttribute
            {
                Name = "White",
                Description = "The color of this longsleeved shirt is white.",
                Type = "bool"
            };
            productAttributeList.Add(productAttribute);

            var attributeGroup = new AttributeGroup
            {
                Name = "Color",
                Description = "The color of the longsleeved shirt.",
                ProductAttributes = productAttributeList
            };
            attributeGroupList.Add(attributeGroup);

            var product = new Product
            {
                Name = "Ralph Lauren",
                Description = "Slim fit, long sleeved shirt.",
                Price = 999
            };
            productList.Add(product);

            var subCategoryDataOne = new Subcategory
            {
                Name = "Long sleeve",
                Products = productList,
                AttributeGroups = attributeGroupList,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today
            };
            subCategoryList.Add(subCategoryDataOne);

            // Category:
            if (!ctx.Categories.Any())
            {
                var category = new Category
                {
                    Name = "Shirts",
                    Subcategories = subCategoryList,
                    UpdatedDate = DateTime.Now.Date,
                    AddedDate = DateTime.Now,
                    Published = false,
                };
                // Adds the categories and all the connections behind:
                ctx.Categories.AddRange(category);
            };

            // The category attributes value:
            if (!ctx.ProductAttributeValues.Any())
            {
                var productAttributeValue = new ProductAttributeValue
                {
                    ProductId = 1,
                    ProductAttributeId = 1,
                    Value = "string"
                };
                ctx.ProductAttributeValues.AddRange(productAttributeValue);
            }

            ctx.SaveChanges();
        }
    }
}
