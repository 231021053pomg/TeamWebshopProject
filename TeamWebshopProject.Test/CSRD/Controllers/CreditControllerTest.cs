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
    public class CreditControllerTest
    {
        private readonly CreditController _controller;
        private readonly Mock<ICreditService> creditService = new();

        public CreditControllerTest()
        {
            _controller = new CreditController(creditService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatuscode200_WhenDataExists()
        {
            // Arrange 
            List<Credit> credits = new List<Credit>();
            credits.Add(new Credit());
            credits.Add(new Credit());

            creditService
                .Setup(s => s.GetAll())
                .ReturnsAsync(credits);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatusCode204_WhenNoDataExists()
        {
            // Arrange
            List<Credit> credits = new List<Credit>();

            creditService
                .Setup(s => s.GetAll())
                .ReturnsAsync(credits);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatusCode500_WhenCreditIsNull()
        {
            // Arrange
            List<Credit> credits = null;

            creditService
                .Setup(s => s.GetAll())
                .ReturnsAsync(credits);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        
        [Fact]
        public async Task Create_ShouldReturnWithStatusCode400_WhenCreditSubmittedIsNull()
        {
            // Arrange
            Credit credit = null;

            creditService
                .Setup(s => s.Create(null))
                .ReturnsAsync(credit);

            // Act
            var response = await _controller.Create(credit);

            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatucCode200_WhenCreditSubmitIsOk()
        {
            // Arrange 
            Credit credit = new Credit { CreditAmount = 0 };

            creditService
                .Setup(s => s.Create(It.IsAny<Credit>()))
                .ReturnsAsync(credit);

            // Act
            var response = await _controller.Create(credit);

            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(200, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task GetById_ShouldReturnCredit_WhenCreditExists()
        {
            // Arrange
            int id = 1;
            int creditAmount = 500;

            Credit credit = new Credit
            {
                Id = id,
                CreditAmount = creditAmount
            };

            creditService
                .Setup(s => s.Get(It.IsAny<int>()))
                .ReturnsAsync(credit);

            // Act
            var response = await _controller.Get(id);

            // Assert
            Assert.NotNull(response);
        }
    }
}
