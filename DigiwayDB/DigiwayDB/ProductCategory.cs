using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigiwayModel
{
    public class ProductCategory
    {
        [Key]
        public long IdProductCategory { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
