using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class SubcategoryController : Controller
    {
        // Get all
        public IActionResult Index()
        {
            return View();
        }

        // Will return single Subcategory
        public IActionResult GetSubCategory()
        {
            return View();
        }

        // Create new Subcategory
        public IActionResult NewSubCategory()
        {
            return View();
        }

        // Updates single Subcategory
        public IActionResult UpdateSubCategory()
        {
            return View();
        }

        // Deletes Subcategory
        public IActionResult DeleteSubCategory()
        {
            return View();
        }
    }
}