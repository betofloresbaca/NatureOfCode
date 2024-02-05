using System.Linq;

namespace PSharp.Static
{
    public static class String
    {
        public static string Join(string[] strings, string separator) =>
            string.Join(separator, strings);

        public static string Nfc(int num, int right = 2) => num.ToString("N" + right);

        public static string[] Nfc(int[] nums, int right = 2) =>
            nums.Select(x => Nfc(x, right)).ToArray();

        public static string Nfc(double num, int right = 2) => num.ToString("N" + right);

        public static string[] Nfc(double[] nums, int right = 2) =>
            nums.Select(x => Nfc(x, right)).ToArray();

        public static string Trim(string str) => str.Trim();
    }
}
