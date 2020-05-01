using Xunit;

namespace Demo.Tests
{
    public class AssertingCollectionsTests
    {
        [Fact]
        public void Employee_Skills_NotIsNullOrWhiteSpace()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Isaac", 10000);

            // Assert
            Assert.All(employee.Skills, habilidade => Assert.False(string.IsNullOrWhiteSpace(habilidade)));
        }

        [Fact]
        public void Employee_Skills_JuniorMustHaveBasicSkill()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Isaac", 1000);

            // Assert
            Assert.Contains("OOP", employee.Skills);
        }


        [Fact]
        public void Employee_Skills_JuniorMustNotHaveAdvancedSkill()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Isaac", 1000);

            // Assert
            Assert.DoesNotContain("Microservices", employee.Skills);
        }


        [Fact]
        public void Employee_Skills_SeniorMustHaveAllSkills()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Isaac", 15000);

            var basicsSkills = new []
            {
                "Logic",
                "OOP",
                "Tests",
                "Microservices"
            };

            // Assert
            Assert.Equal(basicsSkills, employee.Skills);
        }
    }
}