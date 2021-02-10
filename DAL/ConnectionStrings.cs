using System.Collections.Generic;
using System.Diagnostics;

namespace DAL
{
    public static class ConnectionStrings
    {
        private static readonly Dictionary<string, string> dbConnectionStrings =
            new Dictionary<string, string>
            {
                {
                    "localMSSQL",
                    @"data source=(localdb)\MSSQLLocalDB; initial catalog=ApartmentsDB; integrated security=SSPI"
                },
                {"localSQLite", @"Data Source=../A247Database.db"},
                {
                    "sharedSQLExpress",
                    @"Data Source=cassiopeia.serveirc.com\SQLEXPRESS,1433; Initial Catalog = ApartmentsDB;
                                 Integrated Security = FALSE; User ID = Apartments247; password=Janči-je-naprostý-Somár"
                }
            };

        // Api
        private static string localApiVS = @"https://localhost:44306/api/Api/"; // Visual Studio
        private static readonly string localApiConsole = @"http://localhost:5000/api/Api/"; // Console
        private static string sharedApi = @"http://cassiopeia.serveirc.com:5000/api/Api/";

        static ConnectionStrings()
        {
            Debug.WriteLine("******CONNECTIONS******");
            Debug.WriteLine($"[INFO] DB_CONN_STRING={DB_CONN_STRING}");
            Debug.WriteLine($"[INFO] API_URL={API_URL}");
            Debug.WriteLine("******CONNECTIONS******");
        }

        public static string DB_CONN_STRING { get; } = dbConnectionStrings["localSQLite"];

        public static string API_URL { get; } = localApiConsole;
    }
}