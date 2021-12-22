using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTemp1.Data;
using TestTemp1.Models;

namespace TestTemp1.Controllers
{
    [Authorize]
    public class CatergoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CatergoryController(ApplicationDbContext db)     //to make constructor ctor and tab twice
        {
            _db = db;

        }

        public IActionResult Index(string searchString)
        {
            IEnumerable<Catergory> objList = _db.Catergory;
            if (!String.IsNullOrEmpty(searchString))
            {

                return View(_db.Catergory.Where(x => x.Name.Contains(searchString)).ToList());
            }
            return View(objList);

        }
        

        //Get Create
        public IActionResult Create()
        {
            
            return View();
        }

        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catergory obj)
        {
            if (ModelState.IsValid)
            {
                _db.Catergory.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);            
        }

        //Get Edit
        public IActionResult Edit(int ? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Catergory.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catergory obj)
        {
            if (ModelState.IsValid)
            {
                _db.Catergory.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Catergory.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Catergory.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.Catergory.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
            
        }

        
    }
}
