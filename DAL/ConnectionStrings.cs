namespace DAL
{

    public static class ConnectionStrings
    {
        // Database
        public static string LocalDB = @"data source=(localdb)\MSSQLLocalDB; initial catalog=ApartmentsDB; integrated security=SSPI";
        public static string SharedServerDB = @"Data Source=cassiopeia.serveirc.com\SQLEXPRESS,1433; Initial Catalog = ApartmentsDB; Integrated Security = FALSE; User ID = Apartments247; password=Janči-je-naprostý-Somár";


        // Api
        private static string localApiVS = @"https://localhost:44306/api/Api/";          // Visual Studio
        private static string localApiConsole = @"http://localhost:5000/api/Api/";       // Console
        private static string sharedApi = @"http://cassiopeia.serveirc.com:5000/api/Api/";

        public static string API_URL { get; } = localApiConsole;
    }
}
