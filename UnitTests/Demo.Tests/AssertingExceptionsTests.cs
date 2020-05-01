using System;
using Xunit;

namespace Demo.Tests
{
    public class AssertingExceptionsTests
    {
        [Fact]
        public void Calculator_Division_DivideByZeroException()
        {
            // Arrange
            var calculator = new Calculator();

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Division(10, 0));
        }


        [Fact]
        public void Employee_Salary_MustReturnLowerSalaryAllowedError()
        {
            // Arrange & Act & Assert
            var exception =
                Assert.Throws<Exception>(() => EmployeeFactory.Create("Isaac", 250));

            Assert.Equal("Salary less than allowed", exception.Message);
        }
    }
}