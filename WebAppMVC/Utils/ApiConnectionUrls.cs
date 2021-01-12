namespace WebAppMVC.Utils
{
    public static class ApiConnectionUrls
    {
        private static string local = @"https://localhost:44306/api/Sigma/";
        private static string shared = @"http://cassiopeia.serveirc.com:5000/api/Sigma/";

        public static string API_URL { get; } = shared;
    }
}