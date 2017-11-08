using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayModel
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public bool IsCustom { get; set; }
        public long ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
