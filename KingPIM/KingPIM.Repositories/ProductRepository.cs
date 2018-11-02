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
                ctxProduct.Name = p.Name;
                ctxProduct.Description = p.Description;
                ctxProduct.UpdatedDate = DateTime.Now;
                ctxProduct.Version++;
                ctxProduct.SubcategoryId = p.SubcategoryId;
                ctxProduct.Price = p.Price;
            }
        }
        
        // Updates publish value
        public void PublishProduct(MainPageViewModel p)
        {
            var ctxProduct = ctx.Products.FirstOrDefault(x => x.Id.Equals(p.ProductId));

            if (!ctxProduct.Published)
            {
                ctxProduct.Published = true;
            }
            else
            {
                ctxProduct.Published = false;
            }
            ctx.SaveChanges();
        }
    }
}
