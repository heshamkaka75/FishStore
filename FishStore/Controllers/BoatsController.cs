using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishStore.Models;
using FishStore.Repository;

namespace FishStore.Controllers
{
    public class BoatsController : Controller
    {
        private readonly IFishStoreRepo<Boat> boatRepo;

        public BoatsController(IFishStoreRepo<Boat> boatRepo)
        {
            this.boatRepo = boatRepo;
        }

        // GET: Boats
        public IActionResult Index()
        {
            return View(boatRepo.List());
        }

        // GET: Boats/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = boatRepo.Find(id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // GET: Boats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Boat boat)
        {
            if (ModelState.IsValid)
            {
                boatRepo.Add(boat);
                return RedirectToAction(nameof(Index));
            }
            return View(boat);
        }

        // GET: Boats/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = boatRepo.Find(id);
            if (boat == null)
            {
                return NotFound();
            }
            return View(boat);
        }

        // POST: Boats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Boat boat)
        {
            if (id != boat.BoatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    boatRepo.Update(boat);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(boat);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(boat);
        }

        // GET: Boats/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = boatRepo.Find(id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // POST: Boats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            boatRepo.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
