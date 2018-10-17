using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class ProductController : Controller
    {
        // Get all
        public IActionResult Index()
        {
            return View();
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