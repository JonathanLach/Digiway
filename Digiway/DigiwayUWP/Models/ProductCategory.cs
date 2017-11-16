using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayUWP.Models
{
    public class ProductCategory
    {
        public long ProductCategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
