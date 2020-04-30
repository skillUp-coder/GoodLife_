using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeightLossSystem.WebUI.Models
{
    public class SportSupplementViewModel
    {
        public int SportSupplementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string CategoryName { get; set; }
    }
}