using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.BL.DTO;

namespace WeightLossSystem.BL.Interface
{
    public interface IShippingService
    {
        void CreateShipping(ShippingDTO shippingDTO);
        ShippingDTO GetShipping(int ? id);
        IEnumerable<ShippingDTO> GetShippings();
        void Dispose();

    }
}
