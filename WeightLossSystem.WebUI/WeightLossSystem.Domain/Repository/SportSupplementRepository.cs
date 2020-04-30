using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.Domain.EF;
using WeightLossSystem.Domain.Entities;
using WeightLossSystem.Domain.Interfaces;

namespace WeightLossSystem.Domain.Repository
{
    class SportSupplementRepository : IRepositorySportSupplement<SportSupplement>
    {
        ContextDatabase context;
        public SportSupplementRepository(ContextDatabase _context)
        {
            this.context = _context;
        }

        public int Count()
        {
            return context.SportSupplements.Count();
        }

        public void Create(SportSupplement item)
        {
            context.SportSupplements.Add(item);
        }

        public void Delete(int id)
        {
            var data = context.SportSupplements.Find(id);
            if (data != null)
                context.SportSupplements.Remove(data);
        }

        public IEnumerable<SportSupplement> Find(Func<SportSupplement, bool> predicate)
        {
            return context.SportSupplements.Where(predicate).ToList();
        }

        public IEnumerable<string> FindByCategoryName()
        {
            return context.SportSupplements.Select(x => x.CategoryName).Distinct();
        }

        public decimal FindByCost()
        {
            return context.SportSupplements.Select(x=>x.Price).FirstOrDefault();
        }

        public SportSupplement Get(int id)
        {
            return context.SportSupplements.Find(id);
        }

        public IEnumerable<SportSupplement> GetAll()
        {
            return context.SportSupplements;
        }

        public IEnumerable<SportSupplement> GetDatasMatchingCategories(int page, int PageSize, string category)
        {
            return context.SportSupplements.Where(x=>category == null|| x.CategoryName == category).OrderBy(x=>x.Price).Skip((page-1)*PageSize).Take(PageSize);
        }

        public IEnumerable<SportSupplement> GetSortedDatas()
        {
            return context.SportSupplements.OrderByDescending(x => x.Price);
        }

        public int MatchingCategories(string category)
        {
            return context.SportSupplements.Where(x => x.CategoryName == category).Count();
        }



        public void Update(SportSupplement item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;

        }
    }
}
