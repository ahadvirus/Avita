using System;

namespace Avita.Models.Entities.Base;

public class Post
{
    public virtual Guid Id { get; set; }
    
    public virtual string Type { get; set; } = string.Empty;
    
    public virtual string Key { get; set; } = string.Empty;
    
    public virtual string Value { get; set; } = string.Empty;
    
    public virtual Guid Group { get; set; }
}