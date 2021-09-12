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
    public class CenterFishAgenciesController : Controller
    {
        private readonly IFishStoreRepo<CenterFishAgency> storeRepo;
        private readonly IFishStoreRepo<Fish> fishRepo;
        private readonly IFishStoreRepo<Boat> boatRepo;

        public CenterFishAgenciesController(IFishStoreRepo<CenterFishAgency> storeRepo,
                                            IFishStoreRepo<Fish> fishRepo,
                                            IFishStoreRepo<Boat> boatRepo)
        {
            this.storeRepo = storeRepo;
            this.fishRepo = fishRepo;
            this.boatRepo = boatRepo;
        }

        // GET: CenterFishAgencies
        public IActionResult Index()
        {
            var CenterFishAgencies = storeRepo.List();
            return View(CenterFishAgencies);
        }

        // GET: CenterFishAgencies/Details/5
        public IActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var centerFishAgency = storeRepo.Find(id);
            if (centerFishAgency == null)
            {
                return NotFound();
            }

            return View(centerFishAgency);
        }

        // GET: CenterFishAgencies/Create
        public IActionResult Create()
        {
            ViewData["BoatNo"] = new SelectList(boatRepo.List(), "BoatId", "BoatName") ;
            ViewData["FishNo"] = new SelectList(fishRepo.List(), "FishID", "FishName");
            return View();
        }

        // POST: CenterFishAgencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CenterFishAgency centerFishAgency)
        {
            if (ModelState.IsValid)
            {
                storeRepo.Add(centerFishAgency);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoatNo"] = new SelectList(boatRepo.List(), "BoatId", "BoatName", centerFishAgency.BoatNo);
            ViewData["FishNo"] = new SelectList(fishRepo.List(), "FishID", "FishName", centerFishAgency.FishNo);
            return View(centerFishAgency);
        }

        // GET: CenterFishAgencies/Edit/5
        public IActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var centerFishAgency = storeRepo.Find(id);
            if (centerFishAgency == null)
            {
                return NotFound();
            }
            ViewData["BoatNo"] = new SelectList(boatRepo.List(), "BoatId", "BoatName", centerFishAgency.BoatNo);
            ViewData["FishNo"] = new SelectList(fishRepo.List(), "FishID", "FishName", centerFishAgency.FishNo);
            return View(centerFishAgency);
        }

        // POST: CenterFishAgencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,CenterFishAgency centerFishAgency)
        {
            if (id != centerFishAgency.CFA_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    storeRepo.Update(centerFishAgency);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoatNo"] = new SelectList(boatRepo.List(), "BoatId", "BoatName", centerFishAgency.BoatNo);
            ViewData["FishNo"] = new SelectList(fishRepo.List(), "FishID", "FishName", centerFishAgency.FishNo);
            return View(centerFishAgency);
        }

        // GET: CenterFishAgencies/Delete/5
        public IActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var centerFishAgency = storeRepo.Find(id);
            if (centerFishAgency == null)
            {
                return NotFound();
            }

            return View(centerFishAgency);
        }

        // POST: CenterFishAgencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            storeRepo.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }

        // Searching 
        public IActionResult Searching(string word)
        {
            var webSeraching = storeRepo.Search(word);
            return View(webSeraching);
            //return View("index",webSeraching);
        }
    }
}
