using KingPIM.Models;
using KingPIM.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AttributeGroup> AttributeGroups { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
        public DbSet<PreDifinedOptions> preDifinedOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductAttributeValue>().HasKey(k => new { k.ProductAttributeId, k.ProductId });

            modelBuilder.Entity<SubcategoryAttributeGroup>().HasKey(k => new { k.SubcategoryId, k.AttributeGroupId });
        }
    }
}
