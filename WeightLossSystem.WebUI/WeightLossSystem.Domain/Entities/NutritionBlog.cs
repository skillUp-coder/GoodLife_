using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightLossSystem.Domain.Entities
{
    public class NutritionBlog
    {
        public int NutritionBlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string  Text { get; set; }

    }
}
