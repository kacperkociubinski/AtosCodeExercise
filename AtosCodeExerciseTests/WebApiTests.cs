using Application.CQRS.Customers.Commands.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace AtosCodeExerciseTests
{
    [TestClass]
    public class CustomersControllerTests
    {

        private ILogger<CustomersController> _logger = null!;
        private CustomersController customerController = null!;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            this._logger = new Logger<CustomersController>(new LoggerFactory());
            this.customerController = new CustomersController(_logger)
            {
                Mediator = new Mock<IMediator>().Object
            };

        }

        [TestMethod]
        public async Task GetCustomers_ReturnsOkResult()
        {
            // Act
            var result = await customerController.GetCustomers();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateCustomer_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateCustomerCommand();

            // Act
            var result = await customerController.CreateCustomer(command);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteCustomer_ReturnsOkResult()
        {
            // Arrange
            int id = 1;

            // Act
            var result = await customerController.DeleteCustomer(id);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }
    }
}