using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigiwayModel
{
    public class Friendship
    {
        [Key]
        public long FriendshipId;
        public User Friend { get; set; }
    }
}
