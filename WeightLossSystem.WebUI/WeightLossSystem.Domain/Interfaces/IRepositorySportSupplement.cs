using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightLossSystem.Domain.Interfaces
{
    public interface IRepositorySportSupplement<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
        int Count();
        int MatchingCategories(string category);
        IEnumerable<string> FindByCategoryName();
        decimal FindByCost();
        IEnumerable<T> GetDatasMatchingCategories(int page, int PageSize,string category);
        IEnumerable<T> GetSortedDatas();
        IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}
