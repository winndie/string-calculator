using Xunit;

namespace StringCalculator
{
    public class StringCalculatorTest
    {
        [Theory]
        [InlineData(null, 0, null)]
        [InlineData("", 0, null)]
        [InlineData("0", 0, null)]
        [InlineData("1000", 1000, null)]
        [InlineData("1001", 0, null)]
        [InlineData("-1", null, "Negative not allowed")]
        [InlineData("1,2,3", 6, null)]
        [InlineData("1\n2\n3", 6, null)]
        [InlineData("1,2\n3", 6, null)]
        [InlineData("//aB\n1B2a3", 6, null)]
        [InlineData("//aB\n\n1B\na3", null, "Invalid input")]
        [InlineData("1,2%3", null, "Invalid input")]
        public void Add(string? input, int? expected, string? exception)
        {
            try
            {
                // Act
                int result = new StringCalculator().Add(input);
                // Assert
                Assert.Equal(expected, result);
            }
            catch (Exception e)
            {
                Assert.Equal(exception, e?.Message);
            }
        }
    }
}
