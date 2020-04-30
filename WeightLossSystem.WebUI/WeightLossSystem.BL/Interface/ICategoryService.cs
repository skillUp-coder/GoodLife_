using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.BL.DTO;

namespace WeightLossSystem.BL.Interface
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryDTO categoryDTO);
        CategoryDTO GetCategory(int ? id);
        IEnumerable<CategoryDTO> GetCategories();
        void Dispose();
    }
}
