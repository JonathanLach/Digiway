﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayModel
{
    public class Friendship
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long FriendId { get; set; }
        public User Friend { get; set; }
        public bool IsAwaiting { get; set; }
    }
}
