using System.ComponentModel.DataAnnotations;

namespace Avita.Identity.Models.ViewModels;

public class LoginVm
{
    public LoginVm()
    {
        ReturnUrl = string.Empty;
        Username = string.Empty;
        Password = string.Empty;
    }
    public string ReturnUrl { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
}