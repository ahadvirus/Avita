using System;

namespace Avita.Identity.Models.Entities;

public class User
{
    public User()
    {
        Username = string.Empty;
        Password = string.Empty;
    }

    public virtual Guid Id { get; set; }
    public virtual string Username { get; set; }
    public virtual string Password { get; set; }
}