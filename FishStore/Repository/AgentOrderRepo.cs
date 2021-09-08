using FishStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return storeContext.AgentOrders.FirstOrDefault(f => f.OrderId == id);
        }

        public IList<AgentOrder> List()
        {
            return storeContext.AgentOrders.ToList();
        }

        public List<AgentOrder> Search(string text)
        {
            return storeContext.AgentOrders.Where(r => r.Agent.AgentName.Contains(text) || r.Fish.FishName.Contains(text)).ToList();
        }

        public void Update(AgentOrder entity)
        {
            storeContext.AgentOrders.Update(entity);
            storeContext.SaveChanges();
        }
    }
}
