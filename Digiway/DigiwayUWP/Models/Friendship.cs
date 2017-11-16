using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayUWP.Models
{
    public class Friendship
    {
        public long FriendshipId { get; set; }
        public User User { get; set; }
        public User Friend { get; set; }
        public bool IsAwaiting { get; set; }
    }
}
