using FishStore.Models;
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
            var fish = storeContext.Fishs.FirstOrDefault(f => f.FishID == id);
            return fish;
        }

        public IList<Fish> List()
        {
            var fishes = storeContext.Fishs.ToList();
            return fishes;
        }

        public List<Fish> Search(string text)
        {
            var result = storeContext.Fishs.Where(r => r.FishName.Contains(text) || r.ImageUrl.Contains(text));
            return result.ToList();
        }

        public void Update(Fish entity)
        {
            storeContext.Fishs.Update(entity);
            storeContext.SaveChanges();
        }
    }
}
