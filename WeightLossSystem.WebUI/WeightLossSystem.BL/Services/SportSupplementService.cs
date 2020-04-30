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
using AutoMapper;

namespace WeightLossSystem.BL.Services
{
    public class SportSupplementService : ISportSupplementService
    {
        IUnitOfWork Database;
        public SportSupplementService(IUnitOfWork unitOfWork)
        {
            this.Database = unitOfWork;
        }

        public int Count(string Category)
        {
            return Category == null ? Database.SportSupplements.Count() : Database.SportSupplements.MatchingCategories(Category); 
        }

        public void CreateSportSuplement(SportSupplementDTO sportSupplementDTO)
        {
            SportSupplement sportSupplement = new SportSupplement 
            {
                  Description = sportSupplementDTO.Description,
                  Name = sportSupplementDTO.Name,
                  Price = sportSupplementDTO.Price,
                  Date  = sportSupplementDTO.Date,
                  CategoryName = sportSupplementDTO.CategoryName
            };
            if (sportSupplementDTO == null)
                throw new ValidationException("Don`t found data","");
            Database.SportSupplements.Create(sportSupplement);
            Database.Save();
        }

        public IEnumerable<SportSupplementDTO> DatasMatchingCategories(int page, int PageSize, string category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SportSupplement, SportSupplementDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<SportSupplement>, IList<SportSupplementDTO>>(Database.SportSupplements.GetDatasMatchingCategories(page, PageSize, category));
        }
        

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<string> GetByCategoryName()
        {
            return Database.SportSupplements.FindByCategoryName();
        }

        public decimal GetByCost()
        {
            return Database.SportSupplements.FindByCost();
        }

        public SportSupplementDTO GetSportSupplement(int? id)
        {
            if (id == null)
                throw new ValidationException("Don`t found data","");
            var data = Database.SportSupplements.Get(id.Value);
            if (data == null)
                throw new ValidationException("Don`t found data","");
            return new SportSupplementDTO { Description = data.Description, Name = data.Name, Price = data.Price, SportSupplementId = data.SportSupplementId, Date = data.Date, CategoryName = data.CategoryName }; 
        }

        public IEnumerable<SportSupplementDTO> GetSportSupplements()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SportSupplement, SportSupplementDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<SportSupplement>, IList<SportSupplementDTO>>(Database.SportSupplements.GetAll());
        }

        public IEnumerable<SportSupplementDTO> SortedDatas()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SportSupplement, SportSupplementDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<SportSupplement>, IList<SportSupplementDTO>>(Database.SportSupplements.GetSortedDatas());
        }
    }
}
