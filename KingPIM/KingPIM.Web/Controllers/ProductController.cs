using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Models.ViewModels;
using KingPIM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class ProductController : Controller
    {
        // Get access to categoryRepo
        private ICategoryRepository categoryRepo;
        // Get access to subcategoryRepo
        private ISubcategoryRepository subcategoryRepo;
        // Get access to productRepo
        private IProductRepository productRepo;
        public ProductController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, IProductRepository productRepository)
        {
            categoryRepo = categoryRepository;
            subcategoryRepo = subcategoryRepository;
            productRepo = productRepository;
        }
        // Get all
        public IActionResult Index()
        {
            var categories = categoryRepo.GetCategories();
            var subcategories = subcategoryRepo.GetSubcategories();
            var products = productRepo.GetProducts();

            var vm = new MainPageViewModel
            {
                Categories = categories,
                Subcategories = subcategories,
                Products = products
            };

            return View(vm);
        }

        // Will return single product
        public IActionResult GetProduct()
        {
            return View();
        }

        // Create new product
        public IActionResult NewProduct()
        {
            return View();
        }

        // Updates single product
        public IActionResult UpdateProduct()
        {
            return View();
        }

        // Deletes product
        public IActionResult DeleteProduct()
        {
            return View();
        }
    }
}