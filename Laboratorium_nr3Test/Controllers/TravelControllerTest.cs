using Laboratorium_nr3.Controllers;
using Laboratorium_nr3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace Laboratorium_nr3.Tests
{
    public class TravelControllerTests
    {
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfTravels()
        {
            // Arrange
            var mockService = new Mock<ITravelService>();
            mockService.Setup(repo => repo.GetAll()).Returns(new List<Travel>());

            var controller = new TravelController(mockService.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Travel>>(viewResult.ViewData.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Create_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockService = new Mock<ITravelService>();
            var controller = new TravelController(mockService.Object);
            controller.ModelState.AddModelError("Destination", "Required");

            // Act
            var result = controller.Create(It.IsAny<Travel>());

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<Travel>(viewResult.Model);
        }

        // Similarly, you can write tests for other controller actions like Update, Delete, Details, CreateApi, PagedIndex, etc.
    }
}
