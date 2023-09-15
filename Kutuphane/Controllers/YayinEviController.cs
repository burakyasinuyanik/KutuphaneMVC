using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class YayinEviController : Controller
    {
        private readonly IYayinEviRepository _db;

        public YayinEviController(IYayinEviRepository db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View();
        }


        public IActionResult GetAll()
        {
            return Json(new { data = _db.GetAll() });
        }


        //bu metot sadece yayin evi eklemek için bize bir sayfa servis eden bir metotdur:
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(YayinEvi yayinEvi)
        {
            _db.Add(yayinEvi);
            _db.Save();
            return Ok();
        }

        public IActionResult Delete(int id)
        {
          
           _db.Remove( _db.GetById(id));
            _db.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAjax(int id)
        {

            _db.Remove(_db.GetById(id));
            _db.Save();
            return Ok("Çalıştım");
        }



        public IActionResult Update(int id)
        {
            return View(_db.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(YayinEvi yayinEvi)
        {
            _db.Update(yayinEvi);
            _db.Save();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Upsert(YayinEvi yayinEvi)
        {
            if (yayinEvi != null)
            {
                if (yayinEvi.Id == 0)
                {
                    _db.Add(yayinEvi);
                }
                else
                {
                    _db.Update(yayinEvi);
                }

                _db.Save();
            }

            return Ok();   
        }
    }
}
