using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.Domain.Entities;

namespace WeightLossSystem.BL.Interface
{
    public interface ICartService<T> where T:class
    {
        void AddItem(T item, int quantity);
        void ReamoveLine(T item);
        decimal ComputeTotalValue();
        void Clear();
        IEnumerable<CartLine> Lines { get; }
    }
}
