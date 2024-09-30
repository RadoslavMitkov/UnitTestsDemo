using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using UnitTestsDemo.Api.Controllers;
using UnitTestsDemo.Api.Services;

namespace UnitTestsDemo.Api.UnitTests.Controllers;

public class CarsControllerTests
{
    protected const string carMakeFord = "Ford";

    public class GetMethod
    {
        [Fact]
        public async Task EmptyMake_ReturnsBadRequest()
        {
            //Arrange
            var fakeService = new Mock<ICarService>();
            var controller = new CarsController(fakeService.Object);
            var make = "";

            //Act
            var result = await controller.Get(make);
            var actualResult = result.Result as BadRequest;

            //Assert
            actualResult.Should().BeOfType<BadRequest>();
            actualResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task MakeFord_ReturnsOkWithValueFord()
        {
            //Arrange
            var fakeService = new Mock<ICarService>();
            fakeService.Setup(s => s.GetModels(It.IsAny<string>()).Result)
                .Returns([]);
            var controller = new CarsController(fakeService.Object);

            //Act
            var result = await controller.Get(carMakeFord);
            var actualResult = result.Result as Ok<string>;

            //Assert
            actualResult.Should().NotBeNull();
            actualResult.StatusCode.Should().Be(200);
            actualResult.Value.Should().NotBeNull()
                .And.BeOfType<string>()
                .And.Be(carMakeFord);
        }
    }
}
