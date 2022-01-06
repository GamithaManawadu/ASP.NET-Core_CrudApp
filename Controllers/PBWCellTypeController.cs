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
    public class PBWCellTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PBWCellTypeController(ApplicationDbContext db)     //to make constructor ctor and tab twice
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<PBWCellType> objList = _db.PBWCellType;
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
        public IActionResult Create(PBWCellType obj)
        {
            if (ModelState.IsValid)
            {
                _db.PBWCellType.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.PBWCellType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PBWCellType obj)
        {
            if (ModelState.IsValid)
            {
                _db.PBWCellType.Update(obj);
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
            var obj = _db.PBWCellType.Find(id);
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
            var obj = _db.PBWCellType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.PBWCellType.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
