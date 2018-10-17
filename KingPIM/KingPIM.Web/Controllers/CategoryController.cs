using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class CategoryController : Controller
    {
        // Get all
        public IActionResult Index()
        {
            return View();
        }

        // Will return single category
        public IActionResult GetCategory()
        {
            return View();
        }

        // Create new Category
        public IActionResult NewCategory()
        {
            return View();
        }

        // Updates single Category
        public IActionResult UpdateCategory()
        {
            return View();
        }

        // Deletes Category
        public IActionResult DeleteCategory()
        {
            return View();
        }
    }
}