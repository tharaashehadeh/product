﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        [ForeignKey(nameof(LocalUser))]
        public int LocalUserId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual LocalUser? LocalUser { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        
        public  ICollection<OrderDetails> orderDetails { get; set; } = new HashSet<OrderDetails>();

    }
}
