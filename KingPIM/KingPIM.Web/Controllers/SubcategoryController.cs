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
        public SubcategoryController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository)
        {
            categoryRepo = categoryRepository;
            subcategoryRepo = subcategoryRepository;
        }

        // Get all
        public IActionResult Index()
        {
            var categories = categoryRepo.GetCategories();
            var subcategories = subcategoryRepo.GetSubcategories();
            var vm = new MainPageViewModel
            {
                Categories = categories,
                Subcategories = subcategories
            };

            return View(vm);
        }

        // Will return single Subcategory
        public IActionResult GetSubCategory()
        {
            return View();
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

        // Deletes Subcategory
        public IActionResult DeleteSubCategory()
        {
            return View();
        }
    }
}