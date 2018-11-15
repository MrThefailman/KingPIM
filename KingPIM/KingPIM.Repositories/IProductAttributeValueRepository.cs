using KingPIM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Repositories
{
    public interface IProductAttributeValueRepository
    {
        IEnumerable<ProductAttributeValue> ProductAttributeValues { get; }
        IEnumerable<ProductAttributeValue> GetProductAttributeValues();

        void UpdateProductAttributeValue(int ProductAttributeId, int ProductId, string Value);
    }
}
