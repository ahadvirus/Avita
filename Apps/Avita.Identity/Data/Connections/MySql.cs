using Avita.Identity.Data.Contracts;
using FluentNHibernate.Cfg.Db;

namespace Avita.Identity.Data.Connections;

public record MySql : IConnection<MySQLConnectionStringBuilder>
{
    public MySql()
    {
        Server = string.Empty;
        Database = string.Empty;
        UserId = string.Empty;
        Password = string.Empty;
    }
    public string Server { get; init; }

    public uint Port { get; init; }

    public string Database { get; init; }

    public string UserId { get; init; }

    public string Password { get; init; }

    public string ConnectionString
    {
        get
        {
            return string.Empty;
        }
    }

    public void ConnectionExpression(MySQLConnectionStringBuilder connectionExpression)
    {
        
    }
}