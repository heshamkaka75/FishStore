using FishStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FishStore.Repository
{
    public class AgentOrderRepo : IFishStoreRepo<AgentOrder>
    {
        private readonly FishStoreContext storeContext;

        public AgentOrderRepo(FishStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public void Add(AgentOrder entity)
        {
            storeContext.AgentOrders.Add(entity);
            storeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = Find(id);
            storeContext.AgentOrders.Remove(order);
            storeContext.SaveChanges();
        }

        public AgentOrder Find(int id)
        {
            return storeContext.AgentOrders.Include(f => f.Fish).Include(a => a.Agent)
                .FirstOrDefault(f => f.OrderId == id);
        }

        public IList<AgentOrder> List()
        {
            return storeContext.AgentOrders.Include(f => f.Fish).Include(a => a.Agent).ToList();
        }

        public List<AgentOrder> Search(string text)
        {
            return storeContext.AgentOrders
                .Where(r => r.Fish.FishName.Contains(text) || r.Agent.AgentName.Contains(text)).ToList();
        }

        public void Update(AgentOrder entity)
        {
            storeContext.AgentOrders.Update(entity);
            storeContext.SaveChanges();
        }
    }
}
