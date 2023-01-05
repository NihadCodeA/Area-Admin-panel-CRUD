using AdminPanelCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelCRUD.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BrandSliderController : Controller
    {
        private readonly PustokContext _pustokContext;
        public BrandSliderController(PustokContext pustokContext)
        {
            _pustokContext = pustokContext;
        }
        public IActionResult Index()
        {
            List<BrandSlider> brandSliderList = _pustokContext.BrandSliders.ToList();
            return View(brandSliderList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BrandSlider brandSlider)
        {
            _pustokContext.BrandSliders.Add(brandSlider);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            BrandSlider brandSlider = _pustokContext.BrandSliders.Find(id);
            if (brandSlider == null) View("Error");
            return View(brandSlider);
        }
        [HttpPost]
        public IActionResult Update(BrandSlider brandSlider)
        {
            BrandSlider existBrandSlider = _pustokContext.BrandSliders.Find(brandSlider.Id);
            if (brandSlider == null) View("Error");
            existBrandSlider.ImgUrl = brandSlider.ImgUrl;
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id)
        {
            BrandSlider brandSlider = _pustokContext.BrandSliders.Find(id);
            if (brandSlider == null) View("Error");
            return View(brandSlider);
        }
        [HttpPost]
        public IActionResult Delete(BrandSlider brandSlider)
        {
            BrandSlider existBrandSlider = _pustokContext.BrandSliders.Find(brandSlider.Id);
            if (existBrandSlider == null) View("Error");
            _pustokContext.BrandSliders.Remove(existBrandSlider);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
