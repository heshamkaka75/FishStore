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
    public class AgentOrdersController : Controller
    {
        private readonly IFishStoreRepo<AgentOrder> storeRepo;
        private readonly IFishStoreRepo<Agent> agentRepo;
        private readonly IFishStoreRepo<Fish> fishRepo;

        public AgentOrdersController(IFishStoreRepo<AgentOrder> storeRepo,
                                    IFishStoreRepo<Agent> agentRepo,
                                    IFishStoreRepo<Fish> fishRepo)
        {
            this.storeRepo = storeRepo;
            this.agentRepo = agentRepo;
            this.fishRepo = fishRepo;
        }

        // GET: AgentOrders
        public IActionResult Index()
        {
            var fishStoreContext = storeRepo.List();
            return View(fishStoreContext);
        }

        // GET: AgentOrders/Details/5
        public IActionResult Details(int id)
        {


            var agentOrder = storeRepo.Find(id);
            if (agentOrder == null)
            {
                return NotFound();
            }

            return View(agentOrder);
        }

        // GET: AgentOrders/Create
        public IActionResult Create()
        {
            ViewData["AgentNo"] = new SelectList(agentRepo.List(), "AgentId", "AgentName");
            ViewData["FishNo"] = new SelectList(fishRepo.List(), "FishID", "FishName");

            return View();
        }

        // POST: AgentOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AgentOrder agentOrder)
        {
            if (ModelState.IsValid)
            {
                storeRepo.Add(agentOrder);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentNo"] = new SelectList(agentRepo.List(), "AgentId", "AgentName", agentOrder.AgentNo);
            ViewData["FishNo"] = new SelectList(fishRepo.List(), "FishID", "FishName", agentOrder.FishNo);
            return View(agentOrder);
        }

        // GET: AgentOrders/Edit/5
        public IActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var agentOrder = storeRepo.Find(id);
            if (agentOrder == null)
            {
                return NotFound();
            }
            ViewData["AgentNo"] = new SelectList(agentRepo.List(), "AgentId", "AgentName", agentOrder.AgentNo);
            ViewData["FishNo"] = new SelectList(fishRepo.List(), "FishID", "FishName", agentOrder.FishNo);
            return View(agentOrder);
        }

        // POST: AgentOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  AgentOrder agentOrder)
        {
            if (id != agentOrder.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    storeRepo.Update(agentOrder);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentNo"] = new SelectList(agentRepo.List(), "AgentId", "AgentName", agentOrder.AgentNo);
            ViewData["FishNo"] = new SelectList(fishRepo.List(), "FishID", "FishName", agentOrder.FishNo);
            return View(agentOrder);
        }

        // GET: AgentOrders/Delete/5
        public IActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var agentOrder = storeRepo.Find(id);
            if (agentOrder == null)
            {
                return NotFound();
            }

            return View(agentOrder);
        }

        // POST: AgentOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            storeRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
