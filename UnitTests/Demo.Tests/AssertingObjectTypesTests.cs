using Xunit;

namespace Demo.Tests
{
    public class AssertingObjectTypesTests
    {
        [Fact]
        public void EmployeeFactory_Create_MustReturnEmployeeType()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Isaac", 10000);

            // Assert
            Assert.IsType<Employee>(employee);
        }
        
        [Fact]
        public void EmployeeFactory_Create_MustReturnDerivedPersonType()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Isaac", 10000);

            // Assert
            Assert.IsAssignableFrom<Employee>(employee);
        }
    }
}