
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace CinestarDBManager.DBManager;

public sealed class MySqlDbManager : DbManager
{
    private static MySqlDbManager? _instancia;

    private MySqlDbManager(string connectionStringBase)
        : base(connectionStringBase)
    {
    }

    public static MySqlDbManager GetInstance(string connectionStringBase)
    {
        _instancia ??= new MySqlDbManager(connectionStringBase);
        return _instancia;
    }

    public override DbConnection GetConnection()
    {
        var builder = new MySqlConnectionStringBuilder(ConnectionStringBase);

        if (!string.IsNullOrWhiteSpace(builder.Password))
        {
            builder.Password = ResolvePassword(builder.Password) ?? string.Empty;
        }

        return new MySqlConnection(builder.ConnectionString);
    }
}