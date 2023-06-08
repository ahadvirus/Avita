using Avita.Data.Contracts;
using FluentNHibernate.Cfg.Db;

namespace Avita.Data.Connections;

public record SqlServer() : IConnection<MsSqlConnectionStringBuilder>
{
    public string Server { get; init; } = string.Empty;

    public string Database { get; init; } = string.Empty;

    public string UserId { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

    public string ConnectionString
    {
        get
        {
            return (new System.Data.SqlClient.SqlConnectionStringBuilder()
                {
                    DataSource = Server,
                    InitialCatalog = Database,
                    UserID = UserId,
                    Password = Password,
                    IntegratedSecurity = true
                })
                .ConnectionString;
        }
    }

    public void ConnectionExpression(MsSqlConnectionStringBuilder connectionExpression)
    {
        connectionExpression
            .Server(server: Server)
            .Database(database: Database)
            .Username(username: UserId)
            .Password(password: Password)
            .TrustedConnection();
    }
    
}