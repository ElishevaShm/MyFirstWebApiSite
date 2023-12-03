using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string? Password { get; set; }

        [EmailAddress]
        [Required]
        public string? UserName { get; set; }

        [StringLength(15, ErrorMessage = "First name must be between 2 and 15", MinimumLength = 2)]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

    }
}
