using System;

namespace Avita.Models.Entities.Identity;

/// <summary>
/// Using class for authorization system
/// </summary>
public class Role
{
    /// <summary>
    /// Primary key in the table
    /// </summary>
    public virtual Guid Id { get; set; }
    
    /// <summary>
    /// Store name of the role
    /// </summary>
    public virtual string Name { get; set; } = string.Empty;
}