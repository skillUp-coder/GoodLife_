using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.BL.DTO;

namespace WeightLossSystem.BL.Interface
{
    public interface INutritionBlogService
    {
        void CreateBlog(NutritionBlogDTO  nutritionBlogDTO);
        NutritionBlogDTO GetBlog(int? id);
        IEnumerable<NutritionBlogDTO> GetBlogs();
        void Dispose();
    }
}
