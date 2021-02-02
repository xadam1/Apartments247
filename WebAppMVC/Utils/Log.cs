using System.Diagnostics;

namespace WebAppMVC.Utils
{
    public static class Log
    {
        public static void Info(string message) => Debug.WriteLine($"[INFO] {message}");

        public static void Warning(string message) => Debug.WriteLine($"[WARN] {message}");

        public static void Error(string message) => Debug.WriteLine($"[!ERROR!] {message}");

        public static void Called(string functionName, string param = null)
        {
            var paramString = string.Empty;
            if (param != null)
                paramString = $" with params [{param}]";

            Debug.WriteLine($"[CALLED] {functionName}{paramString}");
        }
    }
}