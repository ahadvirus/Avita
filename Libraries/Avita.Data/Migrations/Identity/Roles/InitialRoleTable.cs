using FluentMigrator;

namespace Avita.Data.Migrations.Identity.Roles;

[Migration(version: 20230704090431)]
public class InitialRoleTable : RoleTableMigration
{
    public override void Up()
    {
        Create.Table(tableName: TableName)
            .WithColumn(name: "Id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn(name: NameColumnName).AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table(tableName: TableName);
    }
}