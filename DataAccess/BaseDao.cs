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
                    "Server=tcp:cupcheck-cancer.database.windows.net,1433;Initial Catalog=cc;Persist Security Info=False;User ID=CupcheckCancerAdmin;Password=Bl@ckH0ckeYRedH@wk;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", 
                    DatabaseType.SqlServer2012, SqlClientFactory.Instance));
            });
        }
    }
}

