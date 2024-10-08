﻿using AdminPanelCRUD.Models;
using AdminPanelCRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly PustokContext _pustokContext;
        public HomeController(PustokContext pustokContext)
        {
            _pustokContext = pustokContext;
        }
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                Sliders = _pustokContext.Sliders.ToList(),
                Features = _pustokContext.Features.ToList(),
                BrandSliders = _pustokContext.BrandSliders.ToList(),
            };
            return View(model);
        }
    }
}
