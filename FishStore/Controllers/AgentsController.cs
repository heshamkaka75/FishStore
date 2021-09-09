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
    public class AgentsController : Controller
    {
        private readonly IFishStoreRepo<Agent> storeRepo;

        public AgentsController(IFishStoreRepo<Agent> storeRepo)
        {
            this.storeRepo = storeRepo;
        }

        // GET: Agents
        public IActionResult Index()
        {
            return View(storeRepo.List());
        }

        // GET: Agents/Details/5
        public  IActionResult Details(int id)
        {
            

            var agent = storeRepo.Find(id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // GET: Agents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Agent agent)
        {
            if (ModelState.IsValid)
            {
                storeRepo.Add(agent);
                
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: Agents/Edit/5
        public IActionResult Edit(int id)
        {
            

            var agent = storeRepo.Find(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Agent agent)
        {
            if (id != agent.AgentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    storeRepo.Update(agent);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(agent);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: Agents/Delete/5
        public IActionResult Delete(int id)
        {
            

            var agent = storeRepo.Find(id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            storeRepo.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
