using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity;

public partial class User
{
    public int Id { get; set; }

    [EmailAddress]
    [Required]
    public string? UserName { get; set; }

    [Required]
    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
