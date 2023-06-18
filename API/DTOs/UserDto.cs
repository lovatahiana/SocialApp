using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserDto // This what we return when user is created
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}