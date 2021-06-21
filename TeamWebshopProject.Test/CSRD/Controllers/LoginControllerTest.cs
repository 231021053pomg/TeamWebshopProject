using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Moq;

using TeamWebshopProject.API.CSRD.Controllers;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.Test.CSRD.Controllers
{
    public class LoginControllerTest
    {
        private readonly LoginController _controller;
        private readonly Mock<ILoginService> loginService = new();

        public LoginControllerTest()
        {
            _controller = new LoginController(loginService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus200_WhenDataExists()
        {
            // Arrange
            List<Login> logins = new List<Login>();
            logins.Add(new Login());
            logins.Add(new Login());

            loginService
                .Setup(s => s.GetAll())
                .ReturnsAsync(logins);

            // Act
            var result = await _controller.GetAll();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus204_WhenNoDataExists()
        {
            // Arrange
            List<Login> logins = new List<Login>();

            loginService
                .Setup(s => s.GetAll())
                .ReturnsAsync(logins);

            // Act
            var result = await _controller.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus500_WhenLoginIsNull()
        {
            //Arrange
            List<Login> logins = null;

            loginService
                .Setup(s => s.GetAll())
                .ReturnsAsync(logins);
            //Act
            var result = await _controller.GetAll();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus400_WhenLoginSubmittedIsNull()
        {
            // Arrange
            Login login = null;

            loginService
                .Setup(s => s.Create(null))
                .ReturnsAsync(login);
            // Act
            var response = await _controller.Create(login);
            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus200_WhenLoginSubmitIsOk()
        {
            // Arrange
            Login login = new Login { AccessType = "", Email = "", Password = "" };
            loginService
                .Setup(s => s.Create(It.IsAny<Login>()))
                .ReturnsAsync(login);
            // Act
            var respone = await _controller.Create(login);

            // Assert
            var responeStatusCode = (IStatusCodeActionResult)respone;
            Assert.Equal(200, responeStatusCode.StatusCode);
        }

        [Fact]
        public async Task GetById_ShoudReturnWithBasket_WhenLoginExists()
        {
            // Arrange
            int id = 1;
            string accesstype = "";
            string email = "";
            string password = "";


            Login login = new Login
            {
                Id = id,
                AccessType = accesstype,
                Email = email,
                Password = password

            };

            loginService
                .Setup(s => s.Get(It.IsAny<int>()))
                .ReturnsAsync(login);
            // Act
            var respone = await _controller.Get(id);
            // Assert
            Assert.NotNull(respone);
        }
    }
}
