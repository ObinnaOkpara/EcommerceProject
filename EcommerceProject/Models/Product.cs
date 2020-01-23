using System;
using System.Collections.Generic;

namespace EcommerceProject.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public virtual Type Type { get; set; }
    }
}
