using System.Collections.Generic;

namespace FrontendConsole
{
    static class Utils
    {
        public static (int i, T val)[] Enumerate<T>(System.Collections.Generic.IEnumerable<T> array)
        {
            List<(int, T)> result = new List<(int, T)>();
            int i = 0;
            foreach (T val in array)
            {
                result.Add((i, val));
                i++;
            }
            return result.ToArray();
        }

        public static int Binary(string s)
        {
            int result = 0;
            int bit = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '1')
                {
                    result |= bit;
                }
                bit <<= 1;
            }
            return result;
        }

        public static string FirstOrDefault(string first, string second)
        {
            return (first?.Length != 0) ? first : second;
        }

        public static T[] Concat<T>(System.Collections.Generic.IEnumerable<T> a, System.Collections.Generic.IEnumerable<T> b)
        {
            List<T> result = new List<T>();
            result.AddRange(a);
            result.AddRange(b);
            return result.ToArray();
        }
    }
}