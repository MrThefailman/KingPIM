using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Models.ViewModels;
using KingPIM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class SubcategoryController : Controller
    {
        // Get access to categoryRepo
        private ICategoryRepository categoryRepo;
        // Get access to subcategoryRepo
        private ISubcategoryRepository subcategoryRepo;
        // Get access to productRepo
        private IProductRepository productRepo;
        public SubcategoryController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, IProductRepository productRepository)
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

        // Will return single Subcategory
        public IActionResult Subcategory(int subcategoryId)
        {
            var subcategory = subcategoryRepo.Subcategories.FirstOrDefault(x => x.Id.Equals(subcategoryId));
            
            return View(subcategory);
        }

        // Create new Subcategory
        public IActionResult CreateSubcategory(MainPageViewModel vm)
        {
            subcategoryRepo.CreateSubcategory(vm);

            return RedirectToAction("Index");
        }

        // Updates single Subcategory
        public IActionResult UpdateSubcategory(MainPageViewModel vm)
        {
            var subcategory = subcategoryRepo.Subcategories.FirstOrDefault(x => x.Id.Equals(vm.SubcategoryId));

            if(ModelState.IsValid && vm != null)
            {
                subcategoryRepo.EditSubcategory(vm);
            }

            return RedirectToAction("Index", vm);
        }

        // Updates published value
        public IActionResult PublishSubcategory(MainPageViewModel vm)
        {
            var subcategory = subcategoryRepo.Subcategories.FirstOrDefault(x => x.Id.Equals(vm.SubcategoryId));

            if(ModelState.IsValid && vm != null)
            {
                subcategoryRepo.PublishSubcategory(vm);
            }
            return RedirectToAction("Index");
        }

        // Deletes Subcategory
        public IActionResult DeleteSubCategory(int subcategoryId)
        {
            var delete = subcategoryRepo.DeleteSubcategory(subcategoryId);
            if(delete != null)
            {
                DeleteSubCategory(subcategoryId);
            }

            return RedirectToAction("Index");
        }
    }
}