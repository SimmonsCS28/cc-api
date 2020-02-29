using System;
using System.Data.SqlClient;
using NPoco;

namespace DataAccess
{
    public class BaseDao
    {
        public DatabaseFactory InitializeFactory()
        {
            return DatabaseFactory.Config(x =>
            {
            x.UsingDatabase(() => new Database(
                Environment.GetEnvironmentVariable("CUPCHECKCANCER_DB"),
                    DatabaseType.SqlServer2012, SqlClientFactory.Instance));
            });
        }
    }
}

