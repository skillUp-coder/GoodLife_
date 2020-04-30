using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.Domain.Entities;


namespace WeightLossSystem.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<User> Users { get; }
        IRepositoryNutritionBlog<NutritionBlog> NutritionBlogs { get; }
        IRepositorySportSupplement<SportSupplement> SportSupplements { get; }
        IRepositoryShipping<Shipping> Shippings { get;  }
        
        void Save();
    }
}
