using System;

namespace Avita.Models.Entities.Identity;

public class User
{
    public virtual Guid Id { get; set; }
    public virtual string Username { get; set; } = string.Empty;
    public virtual string Password { get; set; } = string.Empty;
}