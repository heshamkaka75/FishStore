using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Repository
{
    public interface IFishStoreRepo<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        List<TEntity> Search(string text);
    }
}
