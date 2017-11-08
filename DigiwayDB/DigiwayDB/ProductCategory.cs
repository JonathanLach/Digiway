using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayModel
{
    public class ProductCategory
    {
        public long IdProductCategory { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
