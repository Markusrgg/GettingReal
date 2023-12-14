using BeierholmWPF.Model.Exceptions;
using System;

namespace BeierholmWPF.Model
{
    public class Utility
    {
        public int StringToInt(string str)
        {
            return int.TryParse(str, out int i) == true ? i : throw new NotIntException("Not int!");
        }

        public double StringToDouble(string str)
        {
            return double.TryParse(str, out double i) == true ? i : throw new NotDoubleException("Not a double!");
        }

        public string RemoveStringFromInt(string str)
        {
            string final = "";
            foreach (char c in str)
            {
                if (Char.IsDigit(c))
                {
                    final += c;
                }
            }
            return final;
        }

        public string RemovePastMax(string str, int max = 8)
        {
            return str.Substring(0, max);
        }
    }
}
