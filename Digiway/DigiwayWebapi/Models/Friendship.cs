using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayWebapi.Models
{
    public class Friendship
    {
        public User User { get; set; }
        public User Friend { get; set; }
        public bool IsAwaiting { get; set; }
    }
}