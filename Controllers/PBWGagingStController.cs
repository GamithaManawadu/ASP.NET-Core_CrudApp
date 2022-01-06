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
    public class PBWGagingStController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PBWGagingStController(ApplicationDbContext db)     //to make constructor ctor and tab twice
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<PBWGagingSt> objList = _db.PBWGagingSt;
            return View(objList);

        }

        //Get Create
        public IActionResult Create()
        {
            List<PBWCellType> cl = new List<PBWCellType>();
            cl = (from c in _db.PBWCellType select c).ToList();
            cl.Insert(0, new PBWCellType { Id = 0, CellTypeName = "--Select Cell Type--" });

            ViewBag.message = cl;
            return View();
        }

        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PBWGagingSt obj)
        {
            if (ModelState.IsValid)
            {
                _db.PBWGagingSt.Add(obj);
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
            var obj = _db.PBWGagingSt.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            List<PBWCellType> cl = new List<PBWCellType>();
            cl = (from c in _db.PBWCellType select c).ToList();
            cl.Insert(0, new PBWCellType { Id = 0, CellTypeName = "--Select Cell Type--" });

            ViewBag.message = cl;


            return View(obj);
        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PBWGagingSt obj)
        {
            if (ModelState.IsValid)
            {
                _db.PBWGagingSt.Update(obj);
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
            var obj = _db.PBWGagingSt.Find(id);
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
            var obj = _db.PBWGagingSt.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.PBWGagingSt.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
