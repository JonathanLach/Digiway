using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayWebapi.Models
{
    public class UserCompany
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long CompanyId { get; set; }
        public Company Company{ get; set; }
    }
}
