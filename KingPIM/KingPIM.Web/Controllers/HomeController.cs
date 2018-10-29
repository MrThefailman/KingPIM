using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Models.ViewModels;
using KingPIM.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryRepository Repo;
        public HomeController(ICategoryRepository categoryRepository)
        {
            Repo = categoryRepository;
        }
        public IActionResult Index()
        {
            var categories = Repo.GetCategories();
            var vm = new HomeViewModel
            {
                Categories = categories
            };

            return View(vm);
        }
    }
}