using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingPIM.Data;
using KingPIM.Models;
using KingPIM.Models.ViewModels;

namespace KingPIM.Repositories
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        private ApplicationDbContext ctx;
        public ProductAttributeRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<ProductAttribute> ProductAttributes => ctx.ProductAttributes;
        public IEnumerable<ProductAttribute> GetProductAttributes()
        {
            return ProductAttributes;
        }

        public void CreateProductAttribute(MainPageViewModel pa, int AttrGroupId)
        {
            if(pa.Id == 0)
            {
                var AttributeNames = pa.AttributeName.Split("|");

                foreach (var an in AttributeNames)
                {
                    var NameType = an.Split("=");

                    var AttrName = NameType[0].ToString();
                    var AttrType = NameType[1].ToString();

                    var newProdAttr = new ProductAttribute
                    {
                        Name = AttrName,
                        Type = AttrType,
                        AttributeGroupId = AttrGroupId
                    };
                    ctx.ProductAttributes.Add(newProdAttr);

                    var ctxAttrGroup = ctx.AttributeGroups.FirstOrDefault(x => x.Id.Equals(AttrGroupId));

                    //ctx.SaveChanges();
                }
            }
        }

        public ProductAttribute DeleteProductAttribute(int productAttributeId)
        {
            var ctxProdAttr = ctx.ProductAttributes.FirstOrDefault(x => x.Id.Equals(productAttributeId));
            if(ctxProdAttr != null)
            {
                ctx.ProductAttributes.Remove(ctxProdAttr);
                ctx.SaveChanges();
            }
            return ctxProdAttr;
        }

        public void EditProductAttribute(MainPageViewModel pa)
        {
            var ctxProdAttr = ctx.ProductAttributes.FirstOrDefault(x => x.Id.Equals(pa.ProductAttributeId));

            if(ctxProdAttr != null)
            {
                ctxProdAttr.Name = pa.Name;
                ctxProdAttr.Description = pa.Description;
                ctxProdAttr.Type = pa.Type;
            }
        }
    }
}
