using FluentMigrator;

namespace Avita.Identity.Data.Migrations.Users;

[Migration(version: 20230606113757)]
public class InitialIndexUserTable : UserTableMigration
{
    public override void Up()
    {
        Create.Index(indexName: UsernameIndexName)
            .OnTable(tableName: TableName)
            .OnColumn(columnName: UsernameColumnName)
            .Unique();
    }

    public override void Down()
    {
        Delete.Index(indexName: UsernameIndexName)
            .OnTable(tableName: TableName)
            .OnColumn(columnName: UsernameColumnName);
    }
}