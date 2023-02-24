using Microsoft.Data.SqlClient;

namespace A16_TP_1142718_JRompre.DAO
{
    public class ConnectionManager
    {
        IConfiguration configuration;
        private static ConnectionManager instance;

        private ConnectionManager(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        public static ConnectionManager getInstance(IConfiguration _cfg)
        {
            if (instance == null)
            {
                instance = new ConnectionManager(_cfg);
            }
            return instance;
        }

        public SqlConnection getNewConnection()
        {
            return new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }
    }
}
