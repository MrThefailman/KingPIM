using KingPIM.Models;
using KingPIM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> GetProducts();

        void CreateProduct(MainPageViewModel vm);

        Product DeleteProduct(int ProductId);

        void EditProduct(MainPageViewModel s);

        void PublishProduct(MainPageViewModel s);

    }
}
