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
    public class CategoryRepository : IRepository<Category>
    {
        private ContextDatabase context;
        public CategoryRepository(ContextDatabase _context)
        {
            this.context = _context;
        }

        public Category CheckDataRegister(Category user)
        {
            throw new NotImplementedException();
        }

        public Category CheckDatas(Category user)
        {
            throw new NotImplementedException();
        }

        public void Create(Category item)
        {
            context.Categories.Add(item);
        }

        public void Delete(int id)
        {
            Category category = context.Categories.Find(id);
            if (category != null)
                context.Categories.Remove(category);
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return context.Categories.Where(predicate).ToList();
        }

        public Category Get(int id)
        {
            return context.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories;
        }

        public void Update(Category item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
