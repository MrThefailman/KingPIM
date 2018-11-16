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
        // Get access to product attributes
        private IProductAttributeRepository prodAttrRepo;
        // Get access to attributegroups
        private IAttributeGroupRepository attrGroupRepo;
        // Get access to subcategoryAttributeGroups
        private ISubcategoryAttributeGroup subAttrGroupRepo;
        //Get access to ProductAttributeValues
        private IProductAttributeValueRepository prodAttrValueRepo;
        public ProductController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, IProductRepository productRepository, IProductAttributeRepository productAttributeRepository, ISubcategoryAttributeGroup subcategoryAttributeGroup, IAttributeGroupRepository attributeGroupRepository, IProductAttributeValueRepository productAttributeValueRepository)
        {
            categoryRepo = categoryRepository;
            subcategoryRepo = subcategoryRepository;
            productRepo = productRepository;
            prodAttrRepo = productAttributeRepository;
            subAttrGroupRepo = subcategoryAttributeGroup;
            attrGroupRepo = attributeGroupRepository;
            prodAttrValueRepo = productAttributeValueRepository;
        }
        // Get all
        public IActionResult Index()
        {
            var categories = categoryRepo.GetCategories();
            var subcategories = subcategoryRepo.GetSubcategories();
            var products = productRepo.GetProducts();
            var prodAttributes = prodAttrRepo.GetProductAttributes();
            var AttrGroup = attrGroupRepo.GetAttributeGroups();
            var subAttrGroups = subAttrGroupRepo.GetSubcategoryAttributeGroups();
            var prodAttrValue = prodAttrValueRepo.GetProductAttributeValues();

            var vm = new MainPageViewModel
            {
                Categories = categories,
                Subcategories = subcategories,
                Products = products,
                ProductAttributes = prodAttributes,
                AttributeGroups = AttrGroup,
                SubcategoryAttributeGroups = subAttrGroups,
                ProductAttributeValues = prodAttrValue
            };

            return View(vm);
        }

        // Will return single product
        public IActionResult GetProduct()
        {
            return View();
        }

        // Create new product
        public IActionResult CreateProduct(MainPageViewModel vm)
        {
            productRepo.CreateProduct(vm);

            return RedirectToAction("Index");
        }

        // Updates single product
        public IActionResult UpdateProduct(MainPageViewModel vm)
        {
            var product = productRepo.Products.FirstOrDefault(x => x.Id.Equals(vm.ProductId));

            if(ModelState.IsValid && vm != null)
            {
                productRepo.EditProduct(vm);
            }

            return RedirectToAction("Index", vm);
        }

        // Updates published value
        public IActionResult PublishProduct(MainPageViewModel vm)
        {
            var product = productRepo.Products.FirstOrDefault(x => x.Id.Equals(vm.ProductId));

            if(ModelState.IsValid && vm != null)
            {
                productRepo.PublishProduct(vm);
            }
            return RedirectToAction("Index");
        }

        // Deletes product
        public IActionResult DeleteProduct(int productId)
        {
            var delete = productRepo.DeleteProduct(productId);

            if(delete != null)
            {
                DeleteProduct(productId);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UpdateAttributeValue(int ProductAttributeId, int ProductId, string Value)
        {
            prodAttrValueRepo.UpdateProductAttributeValue(ProductAttributeId, ProductId, Value);

            return RedirectToAction("Index");
        }
    }
}