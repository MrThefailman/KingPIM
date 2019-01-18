using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Models.ViewModels;
using KingPIM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class CustomAttributeGroupController : Controller
    {
        private IProductAttributeRepository productAttributeRepo;
        private ICustomAttributeGroupOptionsRepository customAttributeGroupOptionsRepo;
        public CustomAttributeGroupController(
            IProductAttributeRepository productAttributeRepository, 
            ICustomAttributeGroupOptionsRepository customAttributeGroupOptionsRepository)
        {
            productAttributeRepo = productAttributeRepository;
            customAttributeGroupOptionsRepo = customAttributeGroupOptionsRepository;
        }
        public IActionResult Add(MainPageViewModel vm)
        {
            if(vm != null)
            {
                var AttrId = productAttributeRepo.CreateProductAttributeWithCustomOptions(vm);
                customAttributeGroupOptionsRepo.CreatePreDefinedOption(vm, AttrId);
            }
            return RedirectToAction("Index", "Subcategory");
        }
    }
}