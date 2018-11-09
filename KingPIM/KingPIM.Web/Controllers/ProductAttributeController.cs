using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Models.ViewModels;
using KingPIM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class ProductAttributeController : Controller
    {
        // Get access to categoryRepo
        private ICategoryRepository categoryRepo;
        // Get access to subcategoryRepo
        private ISubcategoryRepository subcategoryRepo;
        // Get access to productRepo
        private IProductRepository productRepo;
        // Get access to ProductAttributeRepo
        private IProductAttributeRepository productAttributeRepo;
        public ProductAttributeController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, IProductRepository productRepository, IProductAttributeRepository productAttributeRepository)
        {
            categoryRepo = categoryRepository;
            subcategoryRepo = subcategoryRepository;
            productRepo = productRepository;
            productAttributeRepo = productAttributeRepository;
        }
        // Get all
        public IActionResult Index()
        {
            return View();
        }

        // Will return single Attribute
        public IActionResult GetAttribute()
        {
            return View();
        }

        // Create new Attribute
        public IActionResult CreateAttribute(MainPageViewModel vm)
        {
            return View();
        }

        // Updates single Attribute
        public IActionResult UpdateAttribute()
        {
            return View();
        }

        // Deletes Attribute
        public IActionResult DeleteAttribute()
        {
            return View();
        }
    }
}