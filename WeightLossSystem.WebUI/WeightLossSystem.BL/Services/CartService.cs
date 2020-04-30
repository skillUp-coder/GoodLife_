using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Infrastructure;
using WeightLossSystem.BL.Interface;
using WeightLossSystem.Domain.Entities;
using WeightLossSystem.Domain.Interfaces;

namespace WeightLossSystem.BL.Services
{
    public class CartService : ICartService<SportSupplementDTO>
    {
        private List<CartLine> LineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines { get { return LineCollection; } }


        public void AddItem(SportSupplementDTO item, int quantity)
        {
            CartLine line = LineCollection.Where(g => g.SportSupplement.SportSupplementId == item.SportSupplementId).FirstOrDefault();
            SportSupplement data = new SportSupplement 
            {
                SportSupplementId = item.SportSupplementId,
                CategoryName = item.CategoryName,
                Date = item.Date,
                Description = item.Description,
                Name = item.Name,
                Price = item.Price
            };

            if (line == null)
            {
                LineCollection.Add(new CartLine
                {
                    SportSupplement = data,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }


        public void Clear()
        {
            LineCollection.Clear();
        }

        public decimal ComputeTotalValue()
        {
            return LineCollection.Sum(x => x.SportSupplement.Price * x.Quantity);
        }

        public void ReamoveLine(SportSupplementDTO item)
        {
            LineCollection.RemoveAll(x => x.SportSupplement.SportSupplementId == item.SportSupplementId);
        }
    }

}
