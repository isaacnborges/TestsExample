using Xunit;

namespace Demo.Tests
{
    public class AssertNullBoolTests
    {
        [Fact]
        public void Employee_Name_NotIsNullOrEmpty()
        {
            // Arrange & Act
            var employee = new Employee("", 1000);

            // Assert
            Assert.False(string.IsNullOrEmpty(employee.Name));
        }

        [Fact]
        public void Funcionario_Nickname_MustNotHaveNickname()
        {
            // Arrange & Act
            var employee = new Employee("Isaac", 1000);

            // Assert
            Assert.Null(employee.Nickname);

            // Assert Bool
            Assert.True(string.IsNullOrEmpty(employee.Nickname));
            Assert.False(employee.Nickname?.Length > 0);
        }
    }
}