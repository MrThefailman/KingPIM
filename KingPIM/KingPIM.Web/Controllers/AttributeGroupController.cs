using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class AttributeGroupController : Controller
    {
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