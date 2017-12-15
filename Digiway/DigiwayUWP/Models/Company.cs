using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Models
{
    public class Company
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int TelNum { get; set; }
        public virtual ICollection<UserCompany> Users { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}
