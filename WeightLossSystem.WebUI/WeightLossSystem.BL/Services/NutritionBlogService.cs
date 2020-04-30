using System.Collections.Generic;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Infrastructure;
using WeightLossSystem.BL.Interface;
using WeightLossSystem.Domain.Entities;
using WeightLossSystem.Domain.Interfaces;
using AutoMapper;

namespace WeightLossSystem.BL.Services
{
    public class NutritionBlogService : INutritionBlogService
    {
        IUnitOfWork Database;
        public NutritionBlogService(IUnitOfWork unitOfWork)
        {
            this.Database = unitOfWork;
        }

        public void CreateBlog(NutritionBlogDTO nutritionBlogDTO)
        {
            NutritionBlog nutritionBlog = new NutritionBlog 
            {
                 Description = nutritionBlogDTO.Description,
                 Text = nutritionBlogDTO.Text,
                 Title = nutritionBlogDTO.Title
            };
            if (nutritionBlog == null)
                throw new ValidationException("Don`t found data","");
            Database.NutritionBlogs.Create(nutritionBlog);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public NutritionBlogDTO GetBlog(int? id)
        {
            if (id == null)
                throw new ValidationException("Don`t found data","");
            var GetNutritionBlog = Database.NutritionBlogs.Get(id.Value);
            if (GetNutritionBlog == null)
                throw new ValidationException("Don`t found data","");
            return new NutritionBlogDTO {  Description = GetNutritionBlog.Description, NutritionBlogId = GetNutritionBlog.NutritionBlogId, Text = GetNutritionBlog.Text, Title = GetNutritionBlog.Title };
        }

        public IEnumerable<NutritionBlogDTO> GetBlogs()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NutritionBlog, NutritionBlogDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<NutritionBlog>, IList<NutritionBlogDTO>>(Database.NutritionBlogs.GetAll());
        }
    }
}
