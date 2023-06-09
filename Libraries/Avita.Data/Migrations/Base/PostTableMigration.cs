using FluentMigrator;

namespace Avita.Data.Migrations.Base;

public abstract class PostTableMigration : Migration
{
    protected string TableName
    {
        get
        {
            return "Posts";
        }
    }

    protected string TypeKeyGroupIndexName
    {
        get
        {
            return string.Format(
                format: "IX_{0}_{1}_{2}_{3}",
                args: new object[] { TypeColumnName, KeyColumnName, GroupColumnName, TableName }
            );
        }
    }

    protected string TypeColumnName
    {
        get
        {
            return "Type";
        }
    }
    
    protected string KeyColumnName
    {
        get
        {
            return "Key";
        }
    }
    
    protected string GroupColumnName
    {
        get
        {
            return "Group";
        }
    }
}