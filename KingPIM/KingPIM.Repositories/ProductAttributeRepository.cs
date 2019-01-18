﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingPIM.Data;
using KingPIM.Models;
using KingPIM.Models.Models;
using KingPIM.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KingPIM.Repositories
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        private ApplicationDbContext ctx;
        public ProductAttributeRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<ProductAttribute> ProductAttributes => ctx.ProductAttributes.Include(x => x.PreDeifinedOptions);
        public IEnumerable<ProductAttribute> GetProductAttributes()
        {
            return ProductAttributes;
        }

        public void CreateProductAttribute(MainPageViewModel pa, int AttrGroupId)
        {
            var ctxAttrGroups = ctx.AttributeGroups.Include(x => x.ProductAttributes);
            var AttrGroup = ctxAttrGroups.FirstOrDefault(x => x.Id.Equals(AttrGroupId));

            if (pa.Id == 0 && AttrGroup.ProductAttributes.Count() == 0)
            {
                var attributeGroup = pa.AttributeGroupName.Split("%");

                var attributes = attributeGroup[1];

                var attributeNames = attributes.Split("|");

                foreach (var an in attributeNames)
                {
                    var NameType = an.Split("=");
                    var AttrName = NameType[0].ToString();
                    var AttrType = NameType[1].ToString();

                    if(int.TryParse(AttrType, out int AttrTypeIsInt))
                    {
                        ProductAttribute thisAttr = ctx.ProductAttributes.Find(AttrTypeIsInt);

                        if(!ctx.ProductAttributes.Any(x => x.Id == thisAttr.Id))
                        {
                            var newCustomAttr = new PreDifinedOptions
                            {
                                Name = AttrName,
                                ProductAttributeId = AttrGroupId
                            };
                            ctx.preDifinedOptions.Add(newCustomAttr);
                            ctx.SaveChanges();
                        }
                        else
                        {
                            // TODO: Continue here
                            thisAttrGroup = AttrGroupId;
                            ctx.SaveChanges();
                        }
                        //ctx.ProductAttributes.Add(newProdAttr);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        var newProdAttr = new ProductAttribute
                        {
                            Name = AttrName,
                            Type = AttrType,
                            AttributeGroupId = AttrGroupId
                        };
                        ctx.ProductAttributes.Add(newProdAttr);

                        ctx.SaveChanges();
                    }
                }
            }
        }
        public int CreateProductAttributeWithCustomOptions(MainPageViewModel pa)
        {
            if (pa != null && pa.Id == 0)
            {
                var attribute = pa.AttributeName.Split("%");
                var attributeName = attribute[0];
                var attributeOptions = attribute[1];

                var newProdAttr = new ProductAttribute
                {
                    Name = attributeName,
                    Description = attributeOptions,
                    Type = null
                };
                ctx.ProductAttributes.Add(newProdAttr);
                ctx.SaveChanges();
                return newProdAttr.Id;
            }
            return 0;
        }
        public ProductAttribute DeleteProductAttribute(int productAttributeId)
        {
            var ctxProdAttr = ctx.ProductAttributes.FirstOrDefault(x => x.Id.Equals(productAttributeId));
            if (ctxProdAttr != null)
            {
                ctx.ProductAttributes.Remove(ctxProdAttr);
                ctx.SaveChanges();
            }
            return ctxProdAttr;
        }

        public void EditProductAttribute(MainPageViewModel pa)
        {
            var ctxProdAttr = ctx.ProductAttributes.FirstOrDefault(x => x.Id.Equals(pa.ProductAttributeId));

            if (ctxProdAttr != null)
            {
                ctxProdAttr.Name = pa.Name;
                ctxProdAttr.Description = pa.Description;
                ctxProdAttr.Type = pa.Type;
            }
        }
    }
}
