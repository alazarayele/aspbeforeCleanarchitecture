using System.ComponentModel.DataAnnotations;

namespace asp.Model;

public class Registeration
{

     public Registeration()
    {
        IssuedDate = DateTime.Now;
    }

    [Required]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

     [Display(Name = "Issued Date")]
    public DateTime IssuedDate { get; }
}
