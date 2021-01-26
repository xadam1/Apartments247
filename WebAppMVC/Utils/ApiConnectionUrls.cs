namespace WebAppMVC.Utils
{
    public static class ApiConnectionUrls
    {
        private static string local = @"https://localhost:44306/api/Api/";  // Visual Studio
        //private static string local = @"http://localhost:5000/api/Api/";  // Console
        private static string shared = @"http://cassiopeia.serveirc.com:5000/api/Api/";

        public static string API_URL { get; } = local;
    }
}