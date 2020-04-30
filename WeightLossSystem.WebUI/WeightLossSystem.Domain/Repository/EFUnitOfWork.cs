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
    public class EFUnitOfWork : IUnitOfWork
    {
        private ContextDatabase context;
        private CategoryRepository repositoryCategory;
        private UserRepositry repositryUser;
        private NutritionBlogRepository nutritionBlogRepository;
        private SportSupplementRepository sportSupplementRepository;
        private ShippingRepository repositoryShipping;
        

        public EFUnitOfWork(string connectionString)
        {
            context = new ContextDatabase(connectionString);
        }
       


        public IRepository<Category> Categories { get 
            {
                if (repositoryCategory == null)
                    repositoryCategory = new CategoryRepository(context);
                return repositoryCategory;
            } }

        public IRepository<User> Users { get 
            {
                if (repositryUser == null)
                    repositryUser = new UserRepositry(context);
                return repositryUser;
            } }

        public IRepositoryNutritionBlog<NutritionBlog> NutritionBlogs { get 
            {
                if (nutritionBlogRepository == null)
                    nutritionBlogRepository = new NutritionBlogRepository(context);
                return nutritionBlogRepository;
            } }

        public IRepositorySportSupplement<SportSupplement> SportSupplements { get 
            {
                if (sportSupplementRepository == null)
                    sportSupplementRepository = new SportSupplementRepository(context);
                return sportSupplementRepository;
            } }

        public IRepositoryShipping<Shipping> Shippings { get 
            {
                if (repositoryShipping == null)
                    repositoryShipping = new ShippingRepository(context);
                return repositoryShipping;
            } }

        private bool disposed = false;
        public virtual void Dispose(bool disposing) 
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
