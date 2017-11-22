using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayUWP.Models
{
    public class UserCompany
    {
        public User User { get; set; }
        public Company Company{ get; set; }

        public override string ToString()
        {
            return Company.Name;
        }
    }
}
