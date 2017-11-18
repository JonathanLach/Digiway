﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayWebapi.Models
{
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        public long UserId { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Hashcode { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string IBANAccount { get; set; }
        public string Address { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        [Required]
        public int TelNumber { get; set; }
        [Required]
        public int AccessRights { get; set; }
        [Required]
        public double Money { get; set; }

        public virtual ICollection<UserCompany> Companies { get; set; }
        public virtual ICollection<ActionRecord> ActionRecords { get; set; }
    }
}
