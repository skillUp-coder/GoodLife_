using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.Domain.Entities;

namespace WeightLossSystem.BL.DTO
{
    public class CartLine
    {
        public SportSupplement SportSupplement { get; set; }
        public int Quantity { get; set; }
    }
}
