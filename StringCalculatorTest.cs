using Xunit;

namespace StringCalculator
{
    public class StringCalculatorTest
    {
        private readonly StringCalculator calculator = new ();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Add_EmptyString_ReturnsZero(string? numbers)
        {
            int result = calculator.Add(numbers);

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("1000")]
        [InlineData("1001")]
        public void Add_Integer_ReturnsInteger(string? numbers)
        {
            int result = calculator.Add(numbers);

            if (numbers == "1")
            {
                Assert.Equal(1, result);
            }
            else if (numbers == "1000")
            {
                Assert.Equal(1000, result);
            }
            else if (numbers == "1001")
            {
                Assert.Equal(0, result);
            }
        }

        [Theory]
        [InlineData("All valid integers", "1,2\n3")]
        [InlineData("Ignored integers", "1,2\n3,1001\n1000\n999")]
        [InlineData("User defined delimiters", "//;\n1;2")]
        [InlineData("User defined consecutive delimiters", "//*%\n1*2%3")]
        [InlineData("User defined delimiters (case-insensitive)", "//aB\n1A2b3")]
        public void Add_IntegersWithDelimiters_ReturnsInteger(string name, string? numbers)
        {
            int result = calculator.Add(numbers);

            switch (name)
            {
                case "All valid integers":
                    Assert.Equal(6, result);
                    break;
                case "Ignored integers":
                    Assert.Equal(2005, result);
                    break;
                case "User defined delimiters":
                    Assert.Equal(3, result);
                    break;
                case "User defined consecutive delimiters":
                    Assert.Equal(6, result);
                    break;
                case "User defined delimiters (case-insensitive)":
                    Assert.Equal(6, result);
                    break;
            }
        }

        [Theory]
        [InlineData("Negatives", "1,-2,3,-4")]
        [InlineData("Consecutive delimiters", "1,\n")]
        [InlineData("Delimiters not defined", "1,2%4,5")]
        [InlineData("Invalid user defined delimiters", "//aB0\n1A2b309")]
        public void Add_IntegersWithDelimiters_ThrowsException(string name, string? numbers)
        {
            Action act = () => calculator.Add(numbers);
            Exception exception = Assert.Throws<Exception>(act);

            switch(name)
            {
                case "Negatives":
                    Assert.Equal("Negatives not allowed: -2 -4", exception.Message);
                    break;
                case "Consecutive delimiters":
                    Assert.Equal("Invalid input", exception.Message);
                    break;
                case "Delimiters not defined":
                    Assert.Equal("Invalid input", exception.Message);
                    break;
                case "Invalid user defined delimiters":
                    Assert.Equal("Invalid input", exception.Message);
                    break;
            }
        }


    }
}
