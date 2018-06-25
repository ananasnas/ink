using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ink
{
    public static class insp
    {
        public static bool isValid2(string str)
        {
            string pattern = @"^[\s+,+\d]*$";
            Match isMatch = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        public static bool isValid1(string str)
        {
            string pattern = "^[а-яА-Я]";
            Match isMatch = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        public static bool isValid3(string str)
        {
            string pattern = @"\d{2}-\d{2}-\d{2}";
            Match isMatch = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
