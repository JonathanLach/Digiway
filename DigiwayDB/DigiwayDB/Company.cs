using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayModel
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int TelNum { get; set; }
        public bool IsValidated { get; set; }
        public long UserId { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Company()
        {
            Users = new HashSet<User>();
        }
    }

}
