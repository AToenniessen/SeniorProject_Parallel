using System;
using System.Collections.Generic;
using System.Text;

namespace EwuConnect.Domain.Models.Profile
{
    public class Login
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}