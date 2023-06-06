using FluentNHibernate.Cfg.Db;

namespace Avita.Identity.Data.Contracts;

public interface IConnection<T> where T : ConnectionStringBuilder
{
    /// <summary>
    /// Return a connection string of sql
    /// </summary>
    string ConnectionString { get; }
    void ConnectionExpression(T  connectionExpression);
}