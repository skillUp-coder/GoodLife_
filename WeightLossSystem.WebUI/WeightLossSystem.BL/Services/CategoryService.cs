using AutoMapper;
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
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork Database;
        public CategoryService(IUnitOfWork ofWork)
        {
            this.Database = ofWork;
        }
        public void CreateCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category 
            {
                 Name = categoryDTO.Name,
                 Discription = categoryDTO.Discription
            };
            if (categoryDTO == null)
                throw new ValidationException("Datas are null","");
            Database.Categories.Create(category);
            Database.Save();

        }

        

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg=>cfg.CreateMap<Category,CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, IList<CategoryDTO>>(Database.Categories.GetAll());
             
        }

        public CategoryDTO GetCategory(int? id)
        {
            if (id == null)
                throw new ValidationException("Categoru not found","");
            var category = Database.Categories.Get(id.Value);
            if (category == null)
                throw new ValidationException("Data not found","");
            return new CategoryDTO { Id = category.Id, Name = category.Name };
        }
        
        public void Dispose()
        {
            Database.Dispose();
        }  
    }
}
