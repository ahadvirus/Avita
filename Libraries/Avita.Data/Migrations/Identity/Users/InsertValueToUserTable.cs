using Avita.Models.Entities.Identity;
using FluentMigrator;

namespace Avita.Data.Migrations.Identity.Users;

[Migration(version: 20230606114728)]
public class InsertValueToUserTable : UserTableMigration
{
    protected User Entity
    {
        get
        {
            return new User() { Id = AdminId, Username = "admin", Password = "123@123.com" };
        }
    }

    public override void Up()
    {
        Insert.IntoTable(tableName: TableName)
            .Row(Entity);
    }

    public override void Down()
    {
        Delete.FromTable(tableName: TableName)
            .Row(Entity);
    }
}