using System.Diagnostics;

namespace DAL
{
    public static class ConnectionStrings
    {
        static ConnectionStrings()
        {
            Debug.WriteLine("******CONNECTIONS******");
            Debug.WriteLine($"[INFO] DB_CONN_STRING={DB_CONN_STRING}");
            Debug.WriteLine($"[INFO] API_URL={API_URL}");
            Debug.WriteLine("******CONNECTIONS******");
        }


        // Database
        private static string localDB = @"data source=(localdb)\MSSQLLocalDB; initial catalog=ApartmentsDB; integrated security=SSPI";
        private static string sharedServerDB = @"Data Source=cassiopeia.serveirc.com\SQLEXPRESS,1433; Initial Catalog = ApartmentsDB; Integrated Security = FALSE; User ID = Apartments247; password=Janči-je-naprostý-Somár";

        public static string DB_CONN_STRING { get; } = localDB;

        // Api
        private static string localApiVS = @"https://localhost:44306/api/Api/";          // Visual Studio
        private static string localApiConsole = @"http://localhost:5000/api/Api/";       // Console
        private static string sharedApi = @"http://cassiopeia.serveirc.com:5000/api/Api/";

        public static string API_URL { get; } = localApiConsole;
    }
}
