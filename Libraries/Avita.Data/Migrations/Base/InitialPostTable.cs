using FluentMigrator;

namespace Avita.Data.Migrations.Base;

[Migration(version: 20230609130637)]
public class InitialPostTable : PostTableMigration
{
    public override void Up()
    {
        Create.Table(tableName: TableName)
            .WithColumn(name: "Id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn(name: TypeColumnName).AsString().NotNullable()
            .WithColumn(name: KeyColumnName).AsString().NotNullable()
            .WithColumn(name: "Value").AsString().NotNullable()
            .WithColumn(name: GroupColumnName).AsGuid().NotNullable();

        Create.Index(indexName: TypeKeyGroupIndexName)
            .OnTable(tableName: TableName)
            .OnColumn(columnName: TypeColumnName).Unique()
            .OnColumn(columnName: KeyColumnName).Unique()
            .OnColumn(columnName: GroupColumnName).Unique();
    }

    public override void Down()
    {
        Delete.Index(indexName: TypeKeyGroupIndexName)
            .OnTable(tableName: TableName);
        
        Delete.Table(tableName: TableName);
    }
}