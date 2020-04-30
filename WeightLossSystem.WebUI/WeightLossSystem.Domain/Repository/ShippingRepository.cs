using System;
using System.Collections.Generic;
using System.Linq;
using WeightLossSystem.Domain.EF;
using WeightLossSystem.Domain.Entities;
using WeightLossSystem.Domain.Interfaces;

namespace WeightLossSystem.Domain.Repository
{
    public class ShippingRepository : IRepositoryShipping<Shipping>
    {
        private ContextDatabase context;
        public ShippingRepository(ContextDatabase _context)
        {
            this.context = _context;
        }

        public void Create(Shipping item)
        {
            context.Shippings.Add(item);
        }

        public void Delete(int id)
        {
            Shipping shipping = context.Shippings.Find(id);
            if (shipping != null)
                context.Shippings.Remove(shipping);
        }

        public IEnumerable<Shipping> Find(Func<Shipping, bool> predicate)
        {
            return context.Shippings.Where(predicate).ToList();
        }

        public Shipping Get(int id)
        {
            return context.Shippings.Find(id);
        }

        public IEnumerable<Shipping> GetAll()
        {
            return context.Shippings;
        }

        public void Update(Shipping item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
