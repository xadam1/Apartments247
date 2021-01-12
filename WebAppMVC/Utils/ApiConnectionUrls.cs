namespace WebAppMVC.Utils
{
    public static class ApiConnectionUrls
    {
        public static string Local { get; set; } = @"https://localhost:44306/api/Sigma/";

        public static string Shared { get; set; } = @"http://cassiopeia.serveirc.com:5000/api/Sigma/";
    }
}