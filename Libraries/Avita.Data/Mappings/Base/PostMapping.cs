using Avita.Models.Entities.Base;
using FluentNHibernate.Mapping;

namespace Avita.Data.Mappings.Base;

public class PostMapping : ClassMap<Post>
{
    public PostMapping()
    {
        Id(memberExpression: post => post.Id, column: "Id");

        Map(memberExpression: post => post.Type, columnName: "Type");

        Map(memberExpression: post => post.Key, columnName: "Key");

        Map(memberExpression: post => post.Value, columnName: "Value");

        Map(memberExpression: post => post.Group, columnName: "Group");
        
        Table(tableName: "Posts");
    }
}