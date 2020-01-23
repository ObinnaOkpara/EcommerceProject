using System;
using System.Collections.Generic;

namespace EcommerceProject.Models
{
    public partial class Type
    {
        public Type()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
