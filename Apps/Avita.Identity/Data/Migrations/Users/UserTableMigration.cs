using System;
using FluentMigrator;

namespace Avita.Identity.Data.Migrations.Users;

public abstract class UserTableMigration : Migration
{
    public string TableName
    {
        get
        {
            return "Users";
        }
    }

    public string UsernameIndexName
    {
        get
        {
            return string.Format(format: "IX_{0}_{1}", args: new object?[] { UsernameColumnName, TableName });
        }
    }

    public string UsernameColumnName
    {
        get
        {
            return "Username";
        }
    }

    public Guid AdminId
    {
        get
        {
            return Guid.Parse(input: "4fbb1c95-71b6-40ba-9ab3-0ff3791bffa9");
        }
    }
}