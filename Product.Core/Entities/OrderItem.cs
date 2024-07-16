using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
