using System.Threading.Tasks;

namespace Avita.Identity.Data.Contracts;

public interface IMigratorService
{
    /// <summary>
    /// Checking the database exists in sql server
    /// </summary>
    /// <returns></returns>
    Task EnsureDatabase();

    /// <summary>
    /// Applied the migration not applied yet on sql server
    /// </summary>
    /// <returns></returns>
    Task MigrateUp();

    /// <summary>
    /// Rollback last migration applied in database
    /// </summary>
    /// <returns></returns>
    Task MigrateDown();
}