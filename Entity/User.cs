using System.ComponentModel.DataAnnotations;

namespace Entity;

public class User
{

    [EmailAddress]
    [Required]
    public string UserName { get; set; }


    //[StringLength(8, ErrorMessage = "password can't be more than 8")]
    [Required]
    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int userId { get; set; }

}
