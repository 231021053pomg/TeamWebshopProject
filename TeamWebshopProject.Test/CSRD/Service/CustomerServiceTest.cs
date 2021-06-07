using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Classes;
using TeamWebshopProject.API.CSRD.Services.Classes;
using TeamWebshopProject.API.Models;
using Xunit;

namespace TeamWebshopProject.Test.CSRD.Service
{
    public class CustomerServiceTest
    {
        #region Setup
        private readonly CustomerService _customerService;
        private readonly Mock<CustomerRepository> _mock = new();

        public CustomerServiceTest()
        {
            _customerService = new(_mock.Object);
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedCount = 2;
            List<Customer> credits = new List<Customer> { new Customer { Id = 1 }, new Customer { Id = 2 } };
            _mock
                .Setup(x => x.GetAll())
                .ReturnsAsync(credits);

            // Act
            var result = await _customerService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count());
        }
        #endregion

        #region Get
        [Fact]
        public async Task Get_Success_Test()
        {
            // Arrange
            Customer customer = new Customer { Id = 1 };

            _mock
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(customer);

            // Act
            var result = await _customerService.Get(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customer.Id, result.Id);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Customer newCustomer = new Customer { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Customer>()))
                .ReturnsAsync(newCustomer);

            // Act
            var result = await _customerService.Create(It.IsAny<Customer>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newCustomer.Id, result.Id);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            // Arrange
            Customer customer = new Customer { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Customer>()))
                .ReturnsAsync(customer
                );

            // Act
            var result = await _customerService.Update(It.IsAny<int>(), It.IsAny<Customer>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customer.Id, result.Id);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            Customer customer = new Customer { Id = 1 };

            _mock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .ReturnsAsync(customer);

            // Act
            var result = await _customerService.Delete(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customer.Id, result.Id);
        }
        #endregion
    }
}
