using Xunit;

namespace StringCalculator
{
    public class StringCalculatorTest
    {
        private readonly StringCalculator calculator = new ();

        [Theory]
        [InlineData(null,0)]
        [InlineData("", 0)]
        public void Add_EmptyString_ReturnsZero(string? numbers, int expected)
        {
            // Act
            int result = calculator.Add(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("1000", 1000)]
        [InlineData("1001", 0)]
        public void Add_SingleInteger_ReturnsInteger(string? numbers, int expected)
        {
            // Act
            int result = calculator.Add(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2\n3", 6)]
        [InlineData("1,2\n3,1001\n1000\n999", 2005)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//*%\n1*2%3", 6)]
        [InlineData("//aB\n1A2b3", 6)]
        public void Add_MultipleIntegersWithDelimiters_ReturnsSum(string numbers, int expected)
        {
            // Act
            int result = calculator.Add(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,-2,3,-4", "Negatives not allowed: -2 -4")]
        [InlineData("1,\n", "Invalid input")]
        [InlineData("1,2%4,5", "Invalid input")]
        [InlineData("//aB0\n1A2b309", "Invalid input")]
        public void Add_IntegersWithDelimiters_ThrowsException(string? numbers, string expected)
        {
            Action act = () => calculator.Add(numbers);
            Exception exception = Assert.Throws<Exception>(act);

            Assert.Equal(expected, exception.Message);
        }


    }
}
