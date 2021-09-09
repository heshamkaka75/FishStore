﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishStore.Models;
using FishStore.Repository;
using Microsoft.AspNetCore.Hosting;
using FishStore.ViewModel;
using System.IO;

namespace FishStore.Controllers
{
    public class FishController : Controller
    {
        private readonly IFishStoreRepo<Fish> storeRepo;
        private readonly IWebHostEnvironment webHostEnvironment;

        public FishController(IFishStoreRepo<Fish> storeRepo,
                              IWebHostEnvironment webHostEnvironment)
        {
            this.storeRepo = storeRepo;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Fish
        public IActionResult Index()
        {
            return View(storeRepo.List());
        }

        // GET: Fish/Details/5
        public IActionResult Details(int id)
        {
            
            var fish = storeRepo.Find(id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // GET: Fish/Create
        public IActionResult Create()
        {
            var model = new FishViewModel();
            return View(model);
        }

        // POST: Fish/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FishViewModel fishViewModel)
        {
            if (ModelState.IsValid)
            {
                

                try
                {
                    string filename = string.Empty;

                    if (fishViewModel.ImageFile != null)
                    {
                        string uploadfile = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                        filename = fishViewModel.ImageFile.FileName;
                        string fullpath = Path.Combine(uploadfile, filename);
                        

                        try
                        {

                            fishViewModel.ImageFile.CopyTo(new FileStream(fullpath, FileMode.Create));

                        }
                        catch (Exception)
                        {
                            return View(fishViewModel);
                        }

                    }

                    var fish = new Fish
                    {
                        FishName = fishViewModel.FishName,
                        ImageUrl = filename
                        
                    };
                    storeRepo.Add(fish);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(fishViewModel);
                }

                
            }
            return View(fishViewModel);
        }

        // GET: Fish/Edit/5
        public IActionResult Edit(int id)
        {
            
            var fish = storeRepo.Find(id);
            if (fish == null)
            {
                return NotFound();
            }

            var fishViewModel = new FishViewModel
            {
                FishID = fish.FishID,
                FishName = fish.FishName,
                ImageUrl = fish.ImageUrl
            };

            return View(fishViewModel);
        }

        // POST: Fish/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FishViewModel fishViewModel)
        {
            var fish = storeRepo.Find(fishViewModel.FishID);

            if (id != fish.FishID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var updatedFish = new Fish
                    {
                        FishID = fishViewModel.FishID,
                        FishName = fishViewModel.FishName,
                        ImageUrl = fishViewModel.ImageUrl
                    };

                    storeRepo.Update(updatedFish);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(fishViewModel);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fishViewModel);
        }

        // GET: Fish/Delete/5
        public IActionResult Delete(int id)
        {
            

            var fish = storeRepo.Find(id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // POST: Fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            storeRepo.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }

    }
}
