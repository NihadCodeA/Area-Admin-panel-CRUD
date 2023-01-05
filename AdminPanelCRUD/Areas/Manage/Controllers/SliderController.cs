using AdminPanelCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelCRUD.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly PustokContext _pustokContext;
        public SliderController(PustokContext pustokContext)
        {
            _pustokContext = pustokContext;
        }
        public IActionResult Index()
        {
            List<Slider> sliderList = _pustokContext.Sliders.ToList();
            return View(sliderList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            _pustokContext.Sliders.Add(slider);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Slider slider = _pustokContext.Sliders.Find(id);
            if (slider == null) View("Error");
            return View(slider);
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            Slider existSlider = _pustokContext.Sliders.Find(slider.Id);
            if (slider == null) View("Error");
            existSlider.FirstTitle = slider.FirstTitle;
            existSlider.SecondTitle = slider.SecondTitle;
            existSlider.Description = slider.Description;
            existSlider.RedirectUrl = slider.RedirectUrl;
            existSlider.RedirectUrlText = slider.RedirectUrlText;
            existSlider.ImgUrl = slider.ImgUrl;
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Slider slider = _pustokContext.Sliders.Find(id);
            if (slider == null) View("Error");
            return View(slider);
        }
        [HttpPost]
        public IActionResult Delete(Slider slider)
        {
            Slider existSlider = _pustokContext.Sliders.Find(slider.Id);
            if (existSlider == null) View("Error");
            _pustokContext.Sliders.Remove(existSlider);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
