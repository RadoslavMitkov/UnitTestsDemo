using FluentAssertions;
using UnitTestsDemo.Api.Services;

namespace UnitTestsDemo.Api.UnitTests.Services;

public class CarServiceTests
{
    public class GetModelsMethod
    {
        [Fact]
        public async Task MakeFord_ReturnsMustang()
        {
            //Arrange
            const string make = "Ford";
            var carService = new CarService();

            //Act
            var models = await carService.GetModels(make);

            //Assert
            models.Should().NotBeEmpty()
                .And.HaveCount(1)
                .And.Contain("Mustang");
        }

        [Fact]
        public async Task MakeInvalid_ThrowsArgumentExceptio()
        {
            //Arrange
            const string make = "InvalidMake";
            var carService = new CarService();

            //Act
            var action = () => carService.GetModels(make);

            //Assert
            await action.Should().ThrowAsync<ArgumentException>()
                .WithMessage("Invalid car make");
        }

        //Other way of running tests
        [Theory]
        [InlineData("Honda", new string[] { "Civic", "Accord", "CR-V" })]
        [InlineData("Tesla", new string[] { "Model S", "Model Y" })]
        [InlineData("Ford", new string[] { "Mustang" })]
        public async Task ValidMake_ReturnsExpectedModels(string make, string[] expectedModels)
        {
            //Arrange
            var carService = new CarService();

            //Act
            var models = await carService.GetModels(make);

            //Assert
            models.Should().Equal(expectedModels);
        }
    }
}
