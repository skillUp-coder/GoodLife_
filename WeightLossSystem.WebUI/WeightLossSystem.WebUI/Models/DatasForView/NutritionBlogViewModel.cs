using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeightLossSystem.WebUI.Models.DatasForView
{
    public class NutritionBlogViewModel
    {
        public int NutritionBlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
    }
}