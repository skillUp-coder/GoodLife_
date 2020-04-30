using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightLossSystem.BL.DTO;

namespace WeightLossSystem.BL.Interface
{
    public interface ISportSupplementService
    {
        void CreateSportSuplement(SportSupplementDTO sportSupplementDTO );
        SportSupplementDTO GetSportSupplement(int? id);
        IEnumerable<SportSupplementDTO> GetSportSupplements();
        IEnumerable<SportSupplementDTO> DatasMatchingCategories(int page, int PageSize, string category);
        IEnumerable<SportSupplementDTO> SortedDatas();

        IEnumerable<string> GetByCategoryName();
        decimal GetByCost();

        int Count(string Category);
        void Dispose();
    }
}
