using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayModel
{
    public class User
    {
        public long UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Hashcode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string IBANAccount { get; set; }
        public string Address { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        public int TelNumber { get; set; }
        public int AccessRights { get; set; }

        public double Money { get; set; }

        public virtual ICollection<Friendship> Friends { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<ActionRecord> ActionRecords { get; set; }


        public User()
        {
            Companies = new HashSet<Company>();
        }
    }
}
