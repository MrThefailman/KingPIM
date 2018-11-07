using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingPIM.Data;
using KingPIM.Models;
using KingPIM.Models.ViewModels;

namespace KingPIM.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext ctx;
        public ProductRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        // Reads all products
        public IEnumerable<Product> Products => ctx.Products;
        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        // Add product to DB
        public void CreateProduct(MainPageViewModel vm)
        {
            if(vm.Id == 0)
            {
                var newProd = new Product
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Price = vm.Price,
                    Version = 1,
                    SubcategoryId = vm.SubcategoryId,
                };
                ctx.Products.Add(newProd);
            }
            ctx.SaveChanges();
        }
        
        // Deletes Product from DB
        public Product DeleteProduct(int ProductId)
        {
            var ctxProduct = ctx.Products.FirstOrDefault(x => x.Id.Equals(ProductId));
            if(ctxProduct != null)
            {
                ctx.Products.Remove(ctxProduct);
                ctx.SaveChanges();
            }
            return ctxProduct;
        }

        // Edit product
        public void EditProduct(MainPageViewModel p)
        {
            var ctxProduct = ctx.Products.FirstOrDefault(x => x.Id.Equals(p.ProductId));

            if(ctxProduct != null)
            {
                if(p.Name != ctxProduct.Name && p.Name != null)
                {
                    ctxProduct.Name = p.Name;
                }
                if(p.Description != ctxProduct.Description)
                {
                    ctxProduct.Description = p.Description;
                }
                ctxProduct.UpdatedDate = DateTime.Now;
                ctxProduct.Version++;
                if(p.SubcategoryId != 0)
                {
                    ctxProduct.SubcategoryId = p.SubcategoryId;
                }
                if(p.Price != ctxProduct.Price)
                {
                    ctxProduct.Price = p.Price;
                }
            }
            ctx.SaveChanges();
        }
        
        // Updates publish value
        public void PublishProduct(MainPageViewModel p)
        {
            var ctxProduct = ctx.Products.FirstOrDefault(x => x.Id.Equals(p.ProductId));

            if(ctxProduct != null)
            {
                var ctxSubcategory = ctx.Subcategories.FirstOrDefault(x => x.Id.Equals(ctxProduct.SubcategoryId));
                var ctxCategory = ctx.Categories.FirstOrDefault(x => x.Id.Equals(ctxSubcategory.CategoryId));
                if (!ctxProduct.Published)
                {
                    ctxProduct.Published = true;
                    if(ctxSubcategory.Published != true)
                    {
                        ctxSubcategory.Published = true;
                    }
                    if(ctxCategory.Published != true)
                    {
                        ctxCategory.Published = true;
                    }
                }
                else
                {
                    ctxProduct.Published = false;
                    if(ctxSubcategory.Products.Count(x => x.Published) == 0)
                    {
                        ctxSubcategory.Published = false;
                        if(ctxCategory.Subcategories.Count(x => x.Published) == 0)
                        {
                            ctxCategory.Published = false;
                        }
                    }
                }
            }
            
            ctx.SaveChanges();
        }
    }
}
