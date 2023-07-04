using FluentMigrator;

namespace Avita.Data.Migrations.Identity.Roles;

[Migration(version: 20230704091511)]
public class InitialNameIndexRoleTable : RoleTableMigration
{
    public override void Up()
    {
        Create
            .Index(indexName: NameIndexName)
            .OnTable(tableName: TableName)
            .OnColumn(columnName: NameColumnName)
            .Unique();
    }

    public override void Down()
    {
        Delete.Index(indexName: NameIndexName)
            .OnTable(tableName: TableName)
            .OnColumn(columnName: NameColumnName);
    }
}