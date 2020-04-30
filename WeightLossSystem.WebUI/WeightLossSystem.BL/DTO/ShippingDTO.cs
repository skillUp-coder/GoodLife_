﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightLossSystem.BL.DTO
{
    public class ShippingDTO
    {
        public int ShippingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public bool GiftWrap { get; set; }

    }
}
