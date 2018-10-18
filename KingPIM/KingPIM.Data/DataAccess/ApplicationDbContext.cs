using KingPIM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Data
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext()
        {

        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Subcategory> Subcategorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AttributeGroup> AttributeGroups { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}
