﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGraphQL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedAt { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
