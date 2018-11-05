using KingPIM.Models;
using KingPIM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Repositories
{
    public interface IProductAttributeRepository
    {
        IEnumerable<ProductAttribute> ProductAttributes { get; }
        IEnumerable<ProductAttribute> GetProductAttributes();

        void CreateProductAttribute(MainPageViewModel pa);

        ProductAttribute DeleteProductAttribute(int productAttributeId);

        void EditProductAttribute(MainPageViewModel pa);
    }
}
