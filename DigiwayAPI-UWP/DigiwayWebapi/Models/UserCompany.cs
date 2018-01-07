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
        public virtual User User { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company{ get; set; }
    }
}
