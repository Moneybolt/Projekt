using Laboratorium_nr3.Controllers;
using Laboratorium_nr3.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace Laboratorium_nr3.Tests
{
    public class TravelControllerTests
    {
        [Fact]
        public void IndexReturnsAViewResultWithAListOfTravels()
        {
            
            var mockService = new Mock<ITravelService>();
            mockService.Setup(repo => repo.GetAll()).Returns(new List<Travel>());

            var controller = new TravelController(mockService.Object);

            
            var result = controller.Index();

            
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Travel>>(viewResult.ViewData.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void CreateReturnsViewResultWhenModelStateIsInvalid()
        {
          
            var mockService = new Mock<ITravelService>();
            var controller = new TravelController(mockService.Object);
            controller.ModelState.AddModelError("Destination", "Required");

            
            var result = controller.Create(It.IsAny<Travel>());

            
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<Travel>(viewResult.Model);
        }
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfTravels()
        {
            
            var mockService = new Mock<ITravelService>();
            mockService.Setup(repo => repo.GetAll()).Returns(new List<Travel>());

            var controller = new TravelController(mockService.Object);

            
            var result = controller.Index();

            
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Travel>>(viewResult.ViewData.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Create_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            
            var mockService = new Mock<ITravelService>();
            var controller = new TravelController(mockService.Object);
            controller.ModelState.AddModelError("Start_Place", "Required");

            
            var result = controller.Create(It.IsAny<Travel>());

            
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<Travel>(viewResult.Model);
        }

        [Fact]
        public void Create_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
           
            var mockService = new Mock<ITravelService>();
            var controller = new TravelController(mockService.Object);
            var travel = new Travel { Start_Place = "Paris", Participants = 2 }; 

           
            var result = controller.Create(travel);

           
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Update_ReturnsViewResult_WhenModelStateIsInvalid()
        {
           
            var mockService = new Mock<ITravelService>();
            var controller = new TravelController(mockService.Object);
            controller.ModelState.AddModelError("Destination", "Required");

            
            var result = controller.Update(It.IsAny<Travel>());

            
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<Travel>(viewResult.Model);
        }

        [Fact]
        public void Update_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            
            var mockService = new Mock<ITravelService>();
            var controller = new TravelController(mockService.Object);
            var travel = new Travel { Id = 1, Start_Place = "Paris", Participants = 10 }; 

            
            var result = controller.Update(travel);

            
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

    }
}
