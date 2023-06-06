using Avita.Identity.Data.Contracts;
using FluentNHibernate.Cfg.Db;

namespace Avita.Identity.Data.Connections;

public record SqlServer : IConnection<MsSqlConnectionStringBuilder>
{
    public SqlServer()
    {
        Server = string.Empty;
        Database = string.Empty;
        UserId = string.Empty;
        Password = string.Empty;
    }

    public string Server { get; init; }

    public string Database { get; init; }

    public string UserId { get; init; }

    public string Password { get; init; }

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