using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingPIM.Models.ViewModels;
using KingPIM.Repositories;
using KingPIM.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        // Get access to ProductAttributeRepo
        private IProductAttributeRepository productAttributeRepo;
        // Get access to AttributeGroupRepo
        private IAttributeGroupRepository attributeGroupRepo;
        // Get access to SubcategoryAttributegroupRepo
        private ISubcategoryAttributeGroup subcategoryAttributeGroupRepo;
        public SubcategoryController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, IProductRepository productRepository, IProductAttributeRepository productAttributeRepository, IAttributeGroupRepository attributeGroupRepository, ISubcategoryAttributeGroup subcategoryAttributeGroupRepository)
        {
            categoryRepo = categoryRepository;
            subcategoryRepo = subcategoryRepository;
            productRepo = productRepository;
            productAttributeRepo = productAttributeRepository;
            attributeGroupRepo = attributeGroupRepository;
            subcategoryAttributeGroupRepo = subcategoryAttributeGroupRepository;
        }

        // Get all
        public IActionResult Index()
        {
            var categories = categoryRepo.GetCategories();
            var subcategories = subcategoryRepo.GetSubcategories();
            var products = productRepo.GetProducts();
            var productAttributes = productAttributeRepo.GetProductAttributes();
            var attributeGroups = attributeGroupRepo.GetAttributeGroups();
            var vm = new MainPageViewModel
            {
                Categories = categories,
                Subcategories = subcategories,
                Products = products,
                ProductAttributes = productAttributes,
                AttributeGroups = attributeGroups
            };

            return View(vm);
        }

        // Will return single Subcategory
        public IActionResult Subcategory(int subcategoryId)
        {
            return View();
        }

        // Create new Subcategory
        public IActionResult CreateSubcategory(MainPageViewModel vm)
        {
            if (vm.AttributeGroupName != null)
            {
                var AttrGroupId = attributeGroupRepo.CreateAttributeGroup(vm);

                productAttributeRepo.CreateProductAttribute(vm, AttrGroupId);

                var SubCatId = subcategoryRepo.CreateSubcategory(vm);

                subcategoryAttributeGroupRepo.CreateSubcategoryAttributeGroup(AttrGroupId, SubCatId);
            }
            subcategoryRepo.CreateSubcategory(vm);

            return RedirectToAction("Index");
        }

        // Updates single Subcategory
        public IActionResult UpdateSubcategory(MainPageViewModel vm)
        {
            var subcategory = subcategoryRepo.Subcategories.FirstOrDefault(x => x.Id.Equals(vm.SubcategoryId));

            if (ModelState.IsValid && vm != null)
            {
                subcategoryRepo.EditSubcategory(vm);
            }

            return RedirectToAction("Index", vm);
        }

        // Updates published value
        public IActionResult PublishSubcategory(MainPageViewModel vm)
        {
            var subcategory = subcategoryRepo.Subcategories.FirstOrDefault(x => x.Id.Equals(vm.SubcategoryId));

            if (ModelState.IsValid && vm != null)
            {
                subcategoryRepo.PublishSubcategory(vm);
            }
            return RedirectToAction("Index");
        }

        // Deletes Subcategory
        public IActionResult DeleteSubCategory(int subcategoryId)
        {
            var delete = subcategoryRepo.DeleteSubcategory(subcategoryId);
            if (delete != null)
            {
                DeleteSubCategory(subcategoryId);
            }

            return RedirectToAction("Index");
        }

        public IActionResult SubcategoryExportJSON(int subcategoryId)
        {
            var subcategories = subcategoryRepo.GetSubcategories();
            var getSucategories = ExportHelper.GetSubcategories(subcategories);
            var selectedSubcategory = getSucategories.FirstOrDefault(x => x.Id.Equals(subcategoryId));

            if (subcategoryId == 0)
            {
                var subcategoryJson = JsonConvert.SerializeObject(getSucategories);
                var bytes = Encoding.UTF8.GetBytes(subcategoryJson);
                return File(bytes, "application/ocet-stream", "subcategories.json");
            }
            else
            {
                var selectedSubcategoryJson = JsonConvert.SerializeObject(selectedSubcategory);
                var bytes = Encoding.UTF8.GetBytes(selectedSubcategoryJson);
                return File(bytes, "application/ocet-stream", "subcategory_" + subcategoryId + ".json");
            }
        }
    }
}