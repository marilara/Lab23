using System;
using System.Collections.Generic;

namespace Lab23Breakout.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Funds { get; set; }
    }
}
