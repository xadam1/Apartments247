namespace WebAppMVC.Utils
{
    public static class ApiConnectionUrls
    {
        private static string local = @"https://localhost:5000/api/Api/";
        private static string shared = @"http://cassiopeia.serveirc.com:5000/api/Api/";

        public static string API_URL { get; } = shared;
    }
}