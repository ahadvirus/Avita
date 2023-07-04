using Avita.Models.Entities.Identity;
using FluentMigrator;

namespace Avita.Data.Migrations.Identity.Roles;

[Migration(version: 20230704092305)]
public class InitialAdminAndUserToRoleTable : RoleTableMigration
{
    /// <summary>
    /// Define default value as admin role for table
    /// </summary>
    protected Role AdminEntity
    {
        get
        {
            return new Role() { Id = AdminId, Name = "Admin" };
        }
    }

    /// <summary>
    /// Define default value as admin role for table
    /// </summary>
    protected Role UserEntity
    {
        get
        {
            return new Role() { Id = UserId, Name = "User" };
        }
    }
    
    public override void Up()
    {
        Insert.IntoTable(tableName: TableName)
            .Row(dataAsAnonymousType: AdminEntity);

        Insert.IntoTable(tableName: TableName)
            .Row(dataAsAnonymousType: UserEntity);
    }

    public override void Down()
    {
        Delete.FromTable(tableName: TableName)
            .Row(dataAsAnonymousType: UserEntity);
        
        Delete.FromTable(tableName: TableName)
            .Row(dataAsAnonymousType: AdminEntity);
    }
}