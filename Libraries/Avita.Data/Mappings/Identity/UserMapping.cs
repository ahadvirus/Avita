using Avita.Models.Entities.Identity;
using FluentNHibernate.Mapping;

namespace Avita.Data.Mappings.Identity;

public class UserMapping : ClassMap<User>
{
    public UserMapping()
    {
        Id(memberExpression: user => user.Id, column: nameof(User.Id));

        Map(memberExpression: user => user.Username, columnName: nameof(User.Username));

        Map(memberExpression: user => user.Password, columnName: nameof(User.Password));

        Table(tableName: "Users");
    }
}

/*
public class UserMapping : ClassMapping<Models.Entities.User>
{

    public UserMapping()
    {
        Id(idProperty: user => user.Id, idMapper: mapper =>
        {
            mapper.Generator(generator: NHibernate.Mapping.ByCode.Generators.Guid);
            mapper.Type(persistentType: NHibernate.NHibernateUtil.Guid);
            mapper.Column(columnMapper: column =>
            {
                column.Name(name: nameof(Models.Entities.User));
                column.NotNullable(notnull: true);
            });
            mapper.UnsavedValue(value: System.Guid.Empty);
        });

        Property(property: user => user.Username, mapping: mapper =>
        {
            mapper.Index(indexName: "IX_Username_Users");
            mapper.Unique(unique: true);
            mapper.Column(columnMapper: column =>
            {
                column.Name(name: nameof(Models.Entities.User.Username));
                column.NotNullable(notnull: true);
            });
        });

        Property(property: user => user.Password, mapping: mapper =>
        {
            mapper.Column(columnMapper: column =>
            {
                column.Name(name: nameof(Models.Entities.User.Password));
                column.NotNullable(notnull: true);
            });
        });

        Table(tableName: "Users");
    }
}
*/