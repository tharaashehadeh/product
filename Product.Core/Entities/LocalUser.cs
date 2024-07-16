using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Entities
{
    public class LocalUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; }
        public List<Orders> Orderss { get; set; } = new List<Orders>();

        public virtual ICollection<Orders>Orders  { get; set; } = new HashSet<Orders>();

    }
}
