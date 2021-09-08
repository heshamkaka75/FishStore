using FishStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Repository
{
    public class BoatRepo : IFishStoreRepo<Boat>
    {
        private readonly FishStoreContext storeContext;

        public BoatRepo(FishStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public void Add(Boat entity)
        {
            storeContext.Boats.Add(entity);
            storeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var boat = Find(id);
            storeContext.Boats.Remove(boat);
            storeContext.SaveChanges();
        }

        public Boat Find(int id)
        {
            return storeContext.Boats.FirstOrDefault(f => f.BoatId == id);
        }

        public IList<Boat> List()
        {
            return storeContext.Boats.ToList();
        }

        public List<Boat> Search(string text)
        {
            return storeContext.Boats.Where(r => r.BoatName.Contains(text) || r.Manger.Contains(text)).ToList();
        }

        public void Update(Boat entity)
        {
            storeContext.Boats.Update(entity);
            storeContext.SaveChanges();
        }
    }
}
