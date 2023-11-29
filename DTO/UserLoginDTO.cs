using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserLoginDTO
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }
    }
}
