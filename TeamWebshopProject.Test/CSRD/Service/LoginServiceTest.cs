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
    public class LoginServiceTest
    {
        #region Setup
        private readonly LoginService _customerService;
        private readonly Mock<LoginRepository> _mock = new();

        public LoginServiceTest()
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
            List<Login> logins = new List<Login> { new Login { Id = 1 }, new Login { Id = 2 } };
            _mock
                .Setup(x => x.GetAll())
                .ReturnsAsync(logins);

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
            Login login = new Login { Id = 1 };

            _mock
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(login);

            // Act
            var result = await _customerService.Get(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(login.Id, result.Id);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Login newLogin = new Login { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Login>()))
                .ReturnsAsync(newLogin);

            // Act
            var result = await _customerService.Create(It.IsAny<Login>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newLogin.Id, result.Id);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            // Arrange
            Login login = new Login { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Login>()))
                .ReturnsAsync(login);

            // Act
            var result = await _customerService.Update(It.IsAny<int>(), It.IsAny<Login>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(login.Id, result.Id);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            Login login = new Login { Id = 1 };

            _mock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .ReturnsAsync(login);

            // Act
            var result = await _customerService.Delete(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(login.Id, result.Id);
        }
        #endregion
    }
}
