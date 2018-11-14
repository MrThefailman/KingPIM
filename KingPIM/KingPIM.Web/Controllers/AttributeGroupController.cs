using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class AttributeGroupController : Controller
    {
        // Get access to categoryRepo
        private ICategoryRepository categoryRepo;
        // Get access to subcategoryRepo
        private ISubcategoryRepository subcategoryRepo;
        // Get access to productRepo
        private IProductRepository productRepo;
        // Get access to ProductAttributeRepo
        private IProductAttributeRepository productAttributeRepo;
        // Get access to AttributeGroupRepository
        private IAttributeGroupRepository attributeGroupRepo;
        public AttributeGroupController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, IProductRepository productRepository, IProductAttributeRepository productAttributeRepository, IAttributeGroupRepository attributeGroupRepository)
        {
            categoryRepo = categoryRepository;
            subcategoryRepo = subcategoryRepository;
            productRepo = productRepository;
            productAttributeRepo = productAttributeRepository;
            attributeGroupRepo = attributeGroupRepository;
        }
        // Get all
        public IActionResult Index()
        {
            return View();
        }

        // Will return single AttributeGroup
        public IActionResult GetAttributeGroup()
        {
            return View();
        }

        // Create new Attributegroup
        public IActionResult NewAttributeGroup()
        {

            return View();
        }

        // Updates single Attributegroup
        public IActionResult UpdateAttributegroup()
        {
            return View();
        }

        // Deletes Attributegroup
        public IActionResult DeleteAttributegroup()
        {
            return View();
        }
    }
}