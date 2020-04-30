using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeightLossSystem.BL.DTO;

namespace WeightLossSystem.WebUI.Models.DatasForView
{
    public class SportCategoryViewModel<T> where T:class
    {
        public IList<T> SportSuplements { get; set; }
        public InfoOfPage info { get; set; }
        public string CurrentCategory { get; set; }
    }
}