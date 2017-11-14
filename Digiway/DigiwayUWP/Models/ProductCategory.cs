using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayWindows.Models
{
    public class ProductCategory
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
