using KingPIM.Data;
using KingPIM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Repositories
{
    public class ProductAttributeValueRepository : IProductAttributeValueRepository
    {
        private ApplicationDbContext ctx;
        public ProductAttributeValueRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<ProductAttributeValue> ProductAttributeValues => ctx.ProductAttributeValues.Include(x => x.ProductAttribute).Include(x => x.Product);

        public IEnumerable<ProductAttributeValue> GetProductAttributeValues()
        {
            return ProductAttributeValues;
        }

        public void UpdateProductAttributeValue(int ProductAttributeId, int ProductId, string Value)
        {
            var Check = ctx.ProductAttributeValues.Find(ProductAttributeId, ProductId);
            
            if(ProductAttributeId != 0 && ProductId != 0 && Value != null)
            {
                if(Check == null)
                {
                    var newProdAttrValue = new ProductAttributeValue
                    {
                        Value = Value,
                        ProductId = ProductId,
                        ProductAttributeId = ProductAttributeId
                    };

                    ctx.ProductAttributeValues.Add(newProdAttrValue);

                    ctx.SaveChanges();
                }
                else
                {
                    Check.Value = Value;

                    ctx.SaveChanges();
                }

            }
        }
    }
}
