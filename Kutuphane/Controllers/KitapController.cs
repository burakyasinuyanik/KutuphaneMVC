using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kutuphane.Controllers
{
    public class KitapController:Controller
    {
        //dependency injection ile contextimizi çekelim
        private readonly IKitapRepository _db;
        private readonly IYazarRepository _yazarRepository;
        private readonly IYayinEviRepository _yayinEviRepository;

        public KitapController(IKitapRepository db, IYayinEviRepository yayinEviRepository, IYazarRepository yazarRepository)
        {
            _db = db;
            _yayinEviRepository = yayinEviRepository;
            _yazarRepository = yazarRepository;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult GetAll()
        {
            // _context.Kitaplar.Include(k => k.YayinEvleri).Include(k => k.Yazarlar).ToList();
           // List<Kitap> fullKitap = _context.Kitaplar.Include(k => k.YayinEvleri).Include(k => k.Yazarlar).ToList();
            return Json(new {data=_db.GetAll().ToList()});
        }
        [HttpPost]
        public IActionResult DeleteAjax(int id)
        {

            _db.Remove(_db.GetById(id));
            _db.Save();
            return Ok("Çalıştım");
        }
        public IActionResult Add()
        {
            //ViewData["Yazarlar"] = _db.Yazarlar.ToList();
            //ViewData["YayinEvleri"] = _context.YayinEvleri.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Add(Kitap kitap, List<int> yazarlar,List<int> yayinEvleri)
        {
            foreach(int s in yazarlar)
                kitap.Yazarlar.Add(_yazarRepository.GetById(s));
            
            foreach (int s in yayinEvleri)
                kitap.YayinEvleri.Add(_yayinEviRepository.GetById(s));

         
            _db.Add(kitap);
            _db.Save();
            return Ok();
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            
            return Json(_db.GetById(id));
        }
        public IActionResult Update(int id)
        {
            //ViewData["Yazarlar"] = _context.Yazarlar.ToList();
            //ViewData["YayinEvleri"] = _context.YayinEvleri.ToList();


            return View(_db.GetAll().Where(k => k.Id == id));
        }

        [HttpPost]
        public IActionResult Update(Kitap kitap, List<int> yazarlar, List<int> yayinEvleri)
        {
            
            Kitap asil = _db.GetAll().FirstOrDefault(k => k.Id == kitap.Id); 

            asil.Ad = kitap.Ad;
            asil.ISBN = kitap.ISBN;

            List<Yazar> yazarListesi = new List<Yazar>();
            List<YayinEvi> yayinEvleriListesi = new List<YayinEvi>();
            foreach (int s in yazarlar)
                yazarListesi.Add((_yazarRepository.GetById(s)));

            foreach (int s in yayinEvleri)
               yayinEvleriListesi.Add(_yayinEviRepository.GetById(s));

            asil.Yazarlar = yazarListesi;
            asil.YayinEvleri = yayinEvleriListesi;


            _db.Update(asil);
            _db.Save();
            return RedirectToAction("Index");



        }
    }
}
