namespace StringCalculator
{
    public class StringCalculator
    {
        private char[] _delimiters = new char[] { ',', (char)10 };
        private char[] Delimiters
        {
            get { return _delimiters; }
            set
            {
                _delimiters = value.Select(x =>
                {
                    if (Char.IsDigit(x))
                    {
                        throw new Exception();
                    }
                    return Char.ToLower(x);
                }).ToArray();
            }
        }
        private string DelimitersStart { get; set; } = "//";
        private string DelimitersEnd { get; set; } = "\n";
        private bool IsSuccess { get; set; } = true;
        private string Error { get; set; } = "";

        private readonly int MaxValue = 1000;

        private readonly int MinValue = 0;

        private Dictionary<string, string> Errors = new Dictionary<string, string>
        {
            {"Negatives","Negatives not allowed:"},
            {"Invalid input","Invalid input"},
        };
        private int GetInteger(int number)
        {
            if (number < MinValue)
            {
                if (this.IsSuccess)
                {
                    this.IsSuccess = false;
                    this.Error = Errors["Negatives"];
                }
                this.Error += $" {number}";
            }
            else if (number > MaxValue)
            {
                return MinValue;
            }

            return number;
        }
        private int AddIntegersWithDelimiters(string numbers) => numbers.ToLower().Split(Delimiters).Select(int.Parse).Sum(x => GetInteger(x));
        public int Add(string? numbers = "")
        {
            int result = MinValue;

            if (!string.IsNullOrWhiteSpace(numbers))
            {
                if (int.TryParse(numbers, out result))
                {
                    result = GetInteger(result);
                }
                else
                {
                    try
                    {
                        if (numbers.StartsWith(DelimitersStart))
                        {
                            Delimiters = numbers.Substring(DelimitersStart.Length, numbers.IndexOf(DelimitersEnd) - DelimitersStart.Length).ToCharArray();
                            numbers = numbers.Substring(Delimiters.Length + DelimitersStart.Length + DelimitersEnd.Length);
                        }
                        result = AddIntegersWithDelimiters(numbers);
                    }
                    catch (Exception e)
                    {
                        if (e != null)
                        {
                            this.IsSuccess = false;
                            this.Error = Errors["Invalid input"];
                        }
                    }
                }
            }

            if (!IsSuccess)
            {
                throw new Exception(Error);
            }

            return result;
        }
    }
}
