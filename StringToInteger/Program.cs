using System;
using System.Text.RegularExpressions;

namespace StringToInteger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] strings = { "+-12" };
            foreach(string s in strings)
            {
                Console.WriteLine(MyAtoi(s));
            }
        }

        public static int MyAtoi(string s)
        {
            Regex regex = new(@"^(\s*)*(\+{0,1}\-{0,1}\d+)");
            MatchCollection matches = regex.Matches(s);
            bool condition = matches.Count > 0 ? 
                matches[0].Groups[2].ToString().Contains('-') && !matches[0].Groups[2].ToString().Contains('+') ||
                !matches[0].Groups[2].ToString().Contains('-') && matches[0].Groups[2].ToString().Contains('+') ||
                !matches[0].Groups[2].ToString().Contains('-') && !matches[0].Groups[2].ToString().Contains('+')  ?
                true :
                false : 
                false;
            if(condition)
            {
                string match = matches[0].Groups[2].ToString();
                bool isSuccess = int.TryParse(match, out int result);
                if (isSuccess)
                {
                    return result;
                }
                else
                {
                    if (match.Contains('-'))
                    {
                        return int.MinValue;
                    }
                    else
                    {
                        return int.MaxValue;
                    }
                }
            }
            else
            {
                return 0;
            }
        }
    }
}