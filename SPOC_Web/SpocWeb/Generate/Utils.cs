using System;

namespace SpocWeb.Generate
{
    public class Utils
    {
        private static int _spaceCounter = 4;

        public static String AddTextWithSpaces(string text)
        {
            var a = "";
            return a.PadRight(_spaceCounter) + text;
        }

        public static void IncreaseSpaceCounter()
        {
            _spaceCounter += 4;
        }

        public static void DecreaseSpaceCounter()
        {
            _spaceCounter -= 4;
        }

        public static string UpperCaseFirstLetter(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}