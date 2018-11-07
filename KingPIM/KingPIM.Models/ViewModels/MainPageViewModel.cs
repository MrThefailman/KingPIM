using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingPIM.Models.ViewModels
{
    public class MainPageViewModel
    {
        // To read all the categories
        public IEnumerable<Category> Categories { get; set; }

        // To read all the subcategories
        public IEnumerable<Subcategory> Subcategories { get; set; }

        // To read all products
        public IEnumerable<Product> Products { get; set; }

        // To read attribute groups
        public IEnumerable<AttributeGroup> AttributeGroups { get; set; }

        // To read product attributes
        public IEnumerable<ProductAttribute> productAttributes { get; set; }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public bool Published { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public int SubcategoryId { get; set; }

        public int ProductId { get; set; }

        public int attributeGroupId { get; set; }

        public int productAttributeId { get; set; }

    }
}
