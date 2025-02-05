using System.Linq;
using System;

namespace StringCalculator
{
    public class StringCalculator
    {
        private readonly int Min = 0, Max = 1000;

        private readonly string DelimitersStart = "//", DelimitersEnd = "\n";

        private char[] _delimiters = { ',', (char)10 };

        private char[] Delimiters
        {
            get => _delimiters;
            set => _delimiters = value;
        }
        private int GetResult(int input) => input > Max ? Min : input < Min ? throw new Exception("Negative not allowed") : input;
        public int Add(string? input = null)
        {
            int result = 0;

            if (string.IsNullOrWhiteSpace(input) || int.TryParse(input, out result))
                return GetResult(result);

            try
            {
                if (input.StartsWith(DelimitersStart) && input.Contains(DelimitersEnd))
                {
                    var delimiter = input.Substring(DelimitersStart.Length, input.IndexOf(DelimitersEnd) - DelimitersStart.Length);
                    input = input.Substring(input.IndexOf(DelimitersEnd) + DelimitersEnd.Length);
                    Delimiters = delimiter.ToLower().ToCharArray();
                }
                result = input.ToLower().Split(Delimiters).Sum(x => GetResult(int.Parse(x)));
            }
            catch (Exception e)
            {
                if (e != null)
                    throw new Exception("Invalid input");
            }

            return result;
        }
    }
}
