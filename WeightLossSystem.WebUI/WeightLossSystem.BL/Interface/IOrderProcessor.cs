using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Services;

namespace WeightLossSystem.BL.Interface
{
    public interface IOrderProcessor
    {
        void ProcessOrder(CartService cart, ShippingDTO shippingDTO);
    }
}
