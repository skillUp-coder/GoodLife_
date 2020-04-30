using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.Domain.Entities;

namespace WeightLossSystem.Domain.EF
{
    public class ContextDatabase:DbContext
    {
        public ContextDatabase(string connectionString):base(connectionString){}
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<NutritionBlog> NutritionBlogs { get; set; }
        public DbSet<SportSupplement> SportSupplements { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
    }
}
