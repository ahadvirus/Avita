using System;
using FluentMigrator;

namespace Avita.Data.Migrations.Identity.Roles;

public abstract class RoleTableMigration : Migration
{
    /// <summary>
    /// Return the table name in Database
    /// </summary>
    protected string TableName
    {
        get
        {
            return "Roles";
        }
    }

    /// <summary>
    /// Announce the 'name' column's name
    /// </summary>
    protected string NameColumnName
    {
        get
        {
            return "Name";
        }
    }

    /// <summary>
    /// Represent the name for index of name's column
    /// </summary>
    protected string NameIndexName
    {
        get
        {
            return string.Format(format: "IX_{0}_{1}", args: new object?[] { NameColumnName, TableName });
        }
    }

    /// <summary>
    /// Define the admin role's primary key in table
    /// </summary>
    protected Guid AdminId
    {
        get
        {
            return Guid.Parse(input: "14431113-c010-4932-934b-810be04e24ec");
        }
    }
    
    /// <summary>
    /// Define the user role's primary key in table
    /// </summary>
    protected Guid UserId
    {
        get
        {
            return Guid.Parse(input: "d54c8e15-a71d-434b-9c25-1578e67b813e");
        }
    }
}