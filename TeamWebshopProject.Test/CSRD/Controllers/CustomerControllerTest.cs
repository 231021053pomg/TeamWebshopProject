using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Moq;

using TeamWebshopProject.API.CSRD.Controllers;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.Test.CSRD.Controllers
{
    public class CustomerControllerTest
    {
        private readonly CustomerController _controller;
        private readonly Mock<ICustomerService> customerService = new();

        public CustomerControllerTest()
        {
            _controller = new CustomerController(customerService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatuscode200_WhenDataExists()
        {
            // Arrange
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer());
            customers.Add(new Customer());

            customerService
                .Setup(s => s.GetAll())
                .ReturnsAsync(customers);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatuscode204_WhenNoDataExists()
        {
            // Arrange
            List<Customer> customers = new List<Customer>();

            customerService
                .Setup(s => s.GetAll())
                .ReturnsAsync(customers);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatuscode500_WhenCustomersIsNull()
        {
            // Arrange
            List<Customer> customers = null;

            customerService
                .Setup(s => s.GetAll())
                .ReturnsAsync(customers);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatuscode400_WhenCustomerSubmittedIsNull()
        {
            // Arrange
            Customer customer = null;

            customerService
                .Setup(s => s.Create(null))
                .ReturnsAsync(customer);

            // Act
            var response = await _controller.Create(customer);

            // Assert
            var responseStatuscode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatuscode.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatuscode200_WhenCustomerSubmitIsOk()
        {
            // Arrange
            Customer customer = new Customer
            {
                AddressNumber = 1,
                AddressPostCode = 9999,
                AddressStreet = "Babbaboi",
                UserName = "Perish",
                LastName = "Die"
            };

            customerService
                .Setup(s => s.Create(It.IsAny<Customer>()))
                .ReturnsAsync(customer);

            // Act
            var response = await _controller.Create(customer);

            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(200, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task GetById_ShouldReturnCustomer_WhenCustomerExists()
        {
            // Arrrange
            int id = 1;
            int addressNumber = 1;
            int addressPostCode = 200;
            string addressStreet = "BibiBabaBoi";
            string FirstName = "Albert";
            string lastName = "Andersen";

            Customer customer = new Customer
            {
                Id = id,
                AddressNumber = addressNumber,
                AddressPostCode = addressPostCode,
                AddressStreet = addressStreet,
                FirstName = FirstName,
                LastName = lastName,
            };

            customerService
                .Setup(s => s.Get(It.IsAny<int>()))
                .ReturnsAsync(customer);

            // Act
            var response = await _controller.Get(id);

            // Assert
            Assert.NotNull(response);
        }
    }
}
