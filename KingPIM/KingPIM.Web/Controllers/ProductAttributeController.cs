using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class ProductAttributeController : Controller
    {
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
        public IActionResult NewAttribute()
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