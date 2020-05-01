using Xunit;

namespace Demo.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Add_ReturnSumValue()
        {
            // Arrange
            var calculadora = new Calculator();

            // Act
            var resultado = calculadora.Add(2, 2);

            // Assert
            Assert.Equal(4, resultado);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(4, 2, 6)]
        [InlineData(7, 3, 10)]
        [InlineData(6, 6, 12)]
        [InlineData(9, 9, 18)]
        public void Calculator_Add_ReturnCorrectSumValues(double v1, double v2, double total)
        {
            // Arrange
            var calculadora = new Calculator();

            // Act
            var resultado = calculadora.Add(v1, v2);

            // Assert
            Assert.Equal(total, resultado);
        }

        [Fact]
        public void Calculator_Division_ReturnDivisionValue()
        {
            // Arrange
            var calculadora = new Calculator();

            // Act
            var resultado = calculadora.Division(2, 2);

            // Assert
            Assert.Equal(1, resultado);
        }

        [Theory]
        [InlineData(8, 2, 4)]
        [InlineData(9, 3, 3)]
        public void Calculator_Division_ReturnCorrectDivisionValues(int v1, int v2, double total)
        {
            // Arrange
            var calculadora = new Calculator();

            // Act
            var resultado = calculadora.Division(v1, v2);

            // Assert
            Assert.Equal(total, resultado);
        }
    }
}