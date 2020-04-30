using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.Domain.EF;
using WeightLossSystem.Domain.Entities;
using WeightLossSystem.Domain.Interfaces;
using System.Data.Entity;

namespace WeightLossSystem.Domain.Repository
{
    public class UserRepositry : IRepository<User>
    {
        private ContextDatabase context;
        public UserRepositry(ContextDatabase _context)
        {
            this.context = _context;
        }
        public void Create(User item)
        {
            context.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = context.Users.Find(id);
            if (user != null)
                context.Users.Remove(user);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            throw new Exception("error");
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public void Update(User item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public User CheckDatas(User user) 
        {
            return context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
        }

        public User CheckDataRegister(User user)
        {
            return context.Users.FirstOrDefault(x=>x.Email == user.Email);
        }
    }
}
