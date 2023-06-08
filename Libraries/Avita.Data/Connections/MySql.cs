using Avita.Data.Contracts;
using FluentNHibernate.Cfg.Db;

namespace Avita.Data.Connections;

public record MySql() : IConnection<MySQLConnectionStringBuilder>
{
    public string Server { get; init; } = string.Empty;

    public uint Port { get; init; }

    public string Database { get; init; } = string.Empty;

    public string UserId { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

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