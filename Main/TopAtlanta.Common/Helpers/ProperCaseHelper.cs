using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopAtlanta.Common
{
    public static class ProperCaseHelper
    {
        public static string ToProperCase(this string input)
        {
            if (input == null) return null;

            if (IsAllUpperOrAllLower(input))
            {
                // fix the ALL UPPERCASE or all lowercase names
                return string.Join(" ", input.Split(' ').Select(word => WordToProperCase(word)));
            }
            else
            {
                // leave the CamelCase or Propercase names alone
                return input;
            }
        }

        public static bool IsAllUpperOrAllLower(this string input)
        {
            return (input.ToLower().Equals(input) || input.ToUpper().Equals(input));
        }

        private static string WordToProperCase(string word)
        {
            if (string.IsNullOrEmpty(word)) return word;

            // Standard case
            string ret = CapitaliseFirstLetter(word);

            // Special cases:
            ret = ProperSuffix(ret, "'");   // D'Artagnon, D'Silva
            ret = ProperSuffix(ret, ".");   // ???
            ret = ProperSuffix(ret, "-");       // Oscar-Meyer-Weiner
            ret = ProperSuffix(ret, "Mc");      // Scots
            //ret = ProperSuffix(ret, "Mac");     // Scots

            // Special words:
            ret = SpecialWords(ret, "van");     // Dick van Dyke
            ret = SpecialWords(ret, "von");     // Baron von Bruin-Valt
            ret = SpecialWords(ret, "de");
            ret = SpecialWords(ret, "di");
            ret = SpecialWords(ret, "da");      // Leonardo da Vinci, Eduardo da Silva
            ret = SpecialWords(ret, "of");      // The Grand Old Duke of York
            ret = SpecialWords(ret, "the");     // William the Conqueror
            ret = SpecialWords(ret, "HRH");     // His/Her Royal Highness
            ret = SpecialWords(ret, "HRM");     // His/Her Royal Majesty
            ret = SpecialWords(ret, "H.R.H.");  // His/Her Royal Highness
            ret = SpecialWords(ret, "H.R.M.");  // His/Her Royal Majesty

            ret = DealWithRomanNumerals(ret);   // William Gates, III

            return ret;
        }

        private static string ProperSuffix(string word, string prefix)
        {
            if (string.IsNullOrEmpty(word)) return word;

            string lowerWord = word.ToLower();
            string lowerPrefix = prefix.ToLower();

            if (!lowerWord.Contains(lowerPrefix)) return word;

            int index = lowerWord.IndexOf(lowerPrefix);

            // If the search string is at the end of the word ignore.
            if (index + prefix.Length == word.Length) return word;

            // Fix Comcast
            if (prefix == "Mc" && index > 0) return word;

            return word.Substring(0, index) + prefix +
                CapitaliseFirstLetter(word.Substring(index + prefix.Length));
        }

        private static string SpecialWords(string word, string specialWord)
        {
            if (word.Equals(specialWord, StringComparison.InvariantCultureIgnoreCase))
            {
                return specialWord;
            }
            else
            {
                return word;
            }
        }

        private static string DealWithRomanNumerals(string word)
        {
            List<string> ones = new List<string>() { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            List<string> tens = new List<string>() { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC", "C" };
            // assume nobody uses hundreds

            foreach (string number in ones)
            {
                if (word.Equals(number, StringComparison.InvariantCultureIgnoreCase))
                {
                    return number;
                }
            }

            foreach (string ten in tens)
            {
                foreach (string one in ones)
                {
                    if (word.Equals(ten + one, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return ten + one;
                    }
                }
            }

            return word;
        }

        private static string CapitaliseFirstLetter(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }
    }
}
