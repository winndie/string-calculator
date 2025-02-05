namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string? numbers = "")
        {
            int result = 0;

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
        private int GetInteger(int number)
        {
            if (number < 0)
            {
                if (this.IsSuccess)
                {
                    this.IsSuccess = false;
                    this.Error = Errors["Negatives"];
                }
                this.Error += $" {number}";
            }
            else if (number > 1000)
            {
                return 0;
            }

            return number;
        }
        private int AddIntegersWithDelimiters(string numbers) => numbers.ToLower().Split(Delimiters).Select(int.Parse).Sum(x => GetInteger(x));
        private bool IsSuccess { get; set; } = true;
        private string Error { get; set; } = "";

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

        private Dictionary<string, string> Errors = new Dictionary<string, string>
        {
            {"Negatives","Negatives not allowed:"},
            {"Invalid input","Invalid input"},
        };
    }
}
