using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayUWP.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public bool IsCustom { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
