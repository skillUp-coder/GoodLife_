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
    public class NutritionBlogRepository : IRepositoryNutritionBlog<NutritionBlog>
    {
        private ContextDatabase context;
        public NutritionBlogRepository(ContextDatabase _context)
        {
            this.context = _context;
        }
        public void Create(NutritionBlog item)
        {
            context.NutritionBlogs.Add(item);
        }

        public void Delete(int id)
        {
            var data = context.NutritionBlogs.Find(id);
            if (data != null)
                context.NutritionBlogs.Remove(data);
        }

        public IEnumerable<NutritionBlog> Find(Func<NutritionBlog, bool> predicate)
        {
            return context.NutritionBlogs.Where(predicate).ToList();
        }

        public NutritionBlog Get(int id)
        {
            return context.NutritionBlogs.Find(id);
        }

        public IEnumerable<NutritionBlog> GetAll()
        {
            return context.NutritionBlogs;
        }

        public void Update(NutritionBlog item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;

        }
    }
}
