using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class YazarController : Controller
    {
        //Dependency Injection
        private readonly IYazarRepository _YazarRepo;

        public YazarController(IYazarRepository yazarRepo)
        {
            _YazarRepo = yazarRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data = _YazarRepo.GetAll() });
        }
               
        public IActionResult Delete(int id)
        {
            // Yazar yazar = _context.Yazarlar.Where(y => y.Id == id).First();

           // Yazar yazar = _context.Yazarlar.FirstOrDefault(x => x.Id == id);
          
            _YazarRepo.Remove(_YazarRepo.GetById(id));

            _YazarRepo.Save();


            return RedirectToAction("Index");

        }
             

        public IActionResult Upsert(int id)
        {
            if (id != 0)
            {
                return View(_YazarRepo.GetById(id));
            }
            else {
                return View();
            }
          
        }
        [HttpPost]
        public IActionResult Upsert(Yazar yazar)
        {
            if(yazar.Id==0)
            {
                _YazarRepo.Add(yazar);
                _YazarRepo.Save();
            }
            else
            {
                _YazarRepo.Update(yazar);
                _YazarRepo.Save();
            }
            return RedirectToAction("Index");
        }


    }
}
