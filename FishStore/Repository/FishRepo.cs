using FishStore.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Repository
{
    public class FishRepo : IFishStoreRepo<Fish>
    {
        private readonly FishStoreContext storeContext;
        

        public FishRepo(FishStoreContext storeContext)
        {
            this.storeContext = storeContext;
            
        }
        public void Add(Fish entity)
        {
            storeContext.Fishs.Add(entity);
            storeContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var fish = Find(id);
            storeContext.Fishs.Remove(fish);
            storeContext.SaveChanges();
        }

        public Fish Find(int id)
        {
            return storeContext.Fishs.FirstOrDefault(f => f.FishID == id);
             
        }

        public IList<Fish> List()
        {
            return storeContext.Fishs.ToList();
            
        }

        public List<Fish> Search(string text)
        {
            return storeContext.Fishs.Where(r => r.FishName.Contains(text) || r.ImageUrl.Contains(text)).ToList();
            
        }

        public void Update(Fish entity)
        {
            var newFish = Find(entity.FishID);
            newFish.FishName = entity.FishName;
            newFish.ImageUrl = entity.ImageUrl;
            storeContext.Fishs.Update(newFish);
            storeContext.SaveChanges();
        }
    }
}
