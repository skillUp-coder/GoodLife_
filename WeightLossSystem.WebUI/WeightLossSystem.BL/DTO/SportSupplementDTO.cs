using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightLossSystem.BL.DTO
{
    public class SportSupplementDTO
    {
        public int SportSupplementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string CategoryName { get; set; }
    }
}
