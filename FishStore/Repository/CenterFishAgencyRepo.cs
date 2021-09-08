using FishStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Repository
{
    public class CenterFishAgencyRepo : IFishStoreRepo<CenterFishAgency>
    {
        private readonly FishStoreContext storeContext;

        public CenterFishAgencyRepo(FishStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public void Add(CenterFishAgency entity)
        {
            storeContext.CenterFishAgencies.Add(entity);
            storeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var centerFishAgency = Find(id);
            storeContext.CenterFishAgencies.Remove(centerFishAgency);
            storeContext.SaveChanges();
        }

        public CenterFishAgency Find(int id)
        {
            return storeContext.CenterFishAgencies.FirstOrDefault(f => f.CFA_id == id);
        }

        public IList<CenterFishAgency> List()
        {
            throw new NotImplementedException();
        }

        public List<CenterFishAgency> Search(string text)
        {
            return storeContext.CenterFishAgencies.ToList();
        }

        public void Update(CenterFishAgency entity)
        {
            storeContext.CenterFishAgencies.Update(entity);
            storeContext.SaveChanges();
        }
    }
}
