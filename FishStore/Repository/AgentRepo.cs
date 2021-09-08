using FishStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Repository
{
    public class AgentRepo : IFishStoreRepo<Agent>
    {
        private readonly FishStoreContext storeContext;

        public AgentRepo(FishStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public void Add(Agent entity)
        {
            storeContext.Agents.Add(entity);
            storeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var agent = Find(id);
            storeContext.Agents.Remove(agent);
            storeContext.SaveChanges();
        }

        public Agent Find(int id)
        {
            var agent = storeContext.Agents.FirstOrDefault(a => a.AgentId == id);
            return agent;
        }

        public IList<Agent> List()
        {
            return storeContext.Agents.ToList();
        }

        public List<Agent> Search(string text)
        {
            return storeContext.Agents.Where(r => r.AgentName.Contains(text) || r.Email.Contains(text)).ToList();
        }

        public void Update(Agent entity)
        {
            storeContext.Agents.Update(entity);
            storeContext.SaveChanges();
        }
    }
}
