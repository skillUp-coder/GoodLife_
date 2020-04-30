using System.Collections.Generic;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Infrastructure;
using WeightLossSystem.BL.Interface;
using WeightLossSystem.Domain.Entities;
using WeightLossSystem.Domain.Interfaces;
using AutoMapper;

namespace WeightLossSystem.BL.Services
{
    public class ShippingService : IShippingService
    {
        private IUnitOfWork Database;
        public ShippingService(IUnitOfWork unitOfWork)
        {
            this.Database = unitOfWork;
        }
        public void CreateShipping(ShippingDTO shippingDTO)
        {
            Shipping shipping = new Shipping 
            {
                City = shippingDTO.City,
                Email = shippingDTO.Email,
                FirstName = shippingDTO.FirstName,
                LastName = shippingDTO.LastName,
                GiftWrap = shippingDTO.GiftWrap
            };
            if (shipping == null)
                throw new ValidationException("Don`t found datas","");
            Database.Shippings.Create(shipping);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public ShippingDTO GetShipping(int? id)
        {
            if (id == null)
                throw new ValidationException("Don`t found order","");
            var shipping = Database.Shippings.Get(id.Value);
            if (shipping == null)
                throw new ValidationException("Do`nt found data","");
            return new ShippingDTO 
            {
                City = shipping.City,
                Email = shipping.Email,
                FirstName = shipping.FirstName,
                LastName = shipping.LastName,
                GiftWrap = shipping.GiftWrap
            };
        }

        public IEnumerable<ShippingDTO> GetShippings()
        {
            var mapper = new MapperConfiguration(cfg=>cfg.CreateMap<Shipping, ShippingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Shipping>,IList<ShippingDTO>>(Database.Shippings.GetAll());
        }
    }
}
