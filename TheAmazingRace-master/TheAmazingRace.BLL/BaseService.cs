using System.Collections.Generic;
using TheAmazingRace.DAL;

namespace TheAmazingRace.BLL
{
    public abstract partial class BaseService<T> where T : class, new()
    {
        public BaseRepo<T> Repo { get; set; }

        public bool Add(T t)
        {
            Repo.Add(t);
            return Repo.SaveChanges();
        }

        public bool Delete(T t)
        {
            Repo.Delete(t);
            return Repo.SaveChanges();
        }

        public bool Update(T t)
        {
            Repo.Update(t);
            return Repo.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Repo.GetAll();
        }
    }
}
