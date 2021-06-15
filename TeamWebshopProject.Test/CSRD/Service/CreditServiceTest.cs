using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Classes;
using TeamWebshopProject.API.Models;
using Xunit;

namespace TeamWebshopProject.Test.CSRD.Service
{
    public class CreditServiceTest
    {
        #region Setup
        private readonly CreditService _creditService;
        private readonly Mock<ICreditRepository> _mock = new();

        public CreditServiceTest()
        {
            _creditService = new(_mock.Object);
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedCount = 2;
            List<Credit> credits = new List<Credit> { new Credit { Id = 1 }, new Credit { Id = 2 } };
            _mock
                .Setup(x => x.GetAll())
                .ReturnsAsync(credits);

            // Act
            var result = await _creditService.GetAll();

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
            Credit credit = new Credit { Id = 1 };

            _mock
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(credit);

            // Act
            var result = await _creditService.Get(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(credit.Id, result.Id);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Credit newCredit = new Credit { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Credit>()))
                .ReturnsAsync(newCredit);

            // Act
            var result = await _creditService.Create(It.IsAny<Credit>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newCredit.Id, result.Id);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            // Arrange
            Credit credit = new Credit { Id = 1 };

            _mock
                .Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Credit>()))
                .ReturnsAsync(credit
                );

            // Act
            var result = await _creditService.Update(It.IsAny<int>(), It.IsAny<Credit>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(credit.Id, result.Id);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            Credit credit = new Credit { Id = 1 };

            _mock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .ReturnsAsync(credit);

            // Act
            var result = await _creditService.Delete(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(credit.Id, result.Id);
        }
        #endregion
    }
}
