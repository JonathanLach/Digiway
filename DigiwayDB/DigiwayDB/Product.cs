using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayModel
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsCustom { get; set; }
        public long ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
