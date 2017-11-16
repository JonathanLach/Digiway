﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayUWP.Models
{
    public class Company
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int TelNum { get; set; }
        public virtual ICollection<UserCompany> Users { get; set; }
    }

}
