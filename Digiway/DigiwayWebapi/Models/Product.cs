using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayWebapi.Models
{
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public long ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsCustom { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
