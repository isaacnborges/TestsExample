using Xunit;

namespace Demo.Tests
{
    public class AssertStringsTests
    {
        [Fact]
        public void StringsTools_Join_ReturnFullName()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.Join("Isaac", "Borges");

            // Assert
            Assert.Equal("Isaac Borges", fullName);
        }



        [Fact]
        public void StringsTools_Join_MustIgnoreCase()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.Join("Isaac", "Borges");

            // Assert
            Assert.Equal("ISAAC BORGES", fullName, true);
        }



        [Fact]
        public void StringsTools_Join_Contains()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.Join("Isaac", "Borges");

            // Assert
            Assert.Contains("aac", fullName);
        }


        [Fact]
        public void StringsTools_Join_StartsWith()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.Join("Isaac", "Borges");

            // Assert
            Assert.StartsWith("Isa", fullName);
        }


        [Fact]
        public void StringsTools_Join_EndsWith()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.Join("Isaac", "Borges");

            // Assert
            Assert.EndsWith("ges", fullName);
        }


        [Fact]
        public void StringsTools_Join_ValidarExpressaoRegular()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.Join("Isaac", "Borges");

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", fullName);
        }
    }
}