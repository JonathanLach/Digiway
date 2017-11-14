using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayWindows.Models
{
    public class Friendship
    {
        public User User { get; set; }
        public User Friend { get; set; }
        public bool IsAwaiting { get; set; }
    }
}
