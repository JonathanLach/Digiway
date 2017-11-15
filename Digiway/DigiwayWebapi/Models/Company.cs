using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigiwayWebapi.Models
{
    public class Company
    {
        public long CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int ZIP { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int TelNum { get; set; }
        public virtual ICollection<UserCompany> Users { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}
