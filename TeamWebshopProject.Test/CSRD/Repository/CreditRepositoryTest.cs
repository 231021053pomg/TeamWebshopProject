using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Classes;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;
using Xunit;

namespace TeamWebshopProject.Test.CSRD.Repository
{
    public class CreditRepositoryTest
    {
        #region setup
        private DbContextOptions<TeamWebshopDbContext> _options;
        private readonly TeamWebshopDbContext _context;

        public CreditRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TeamWebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "CreditDatabase")
                .Options;

            _context = new(_options);
            _context.Database.EnsureDeleted();
            _context.Add(new Credit
            {
                Id = 1,
                CreditAmount = 27.7m
            });
            _context.Add(new Credit
            {
                Id = 2,
                CreditAmount = 133.7m
            });
            _context.Add(new Credit
            {
                Id = 3,
                CreditAmount = 4.20m
            });
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedResult = 3;
            CreditRepository creditRepository = new(_context);

            // Act
            var result = await creditRepository.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Count());
        }
        #endregion

        #region Get
        [Fact]
        public async Task Get_Success_Test()
        {
            // Arrange
            int id = 1;
            Credit expectedResult = new Credit
            {
                Id = 1,
                CreditAmount = 15.1m
            };
            CreditRepository creditRepository = new(_context);

            // Act
            var result = await creditRepository.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.CreditAmount, result.CreditAmount);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Credit newCredit = new Credit
            {
                CreditAmount = 20m
            };
            CreditRepository creditRepository = new(_context);

            // Act
            var result = await creditRepository.Create(newCredit);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.CreatedAt);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            // Arrange
            CreditRepository creditRepository = new(_context);
            Credit updatedCredit = new Credit
            {
                Id = 1,
                CreditAmount = 100.0m
            };

            // Act
            var result = await creditRepository.Update(updatedCredit.Id, updatedCredit);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.EditedAt);
            Assert.Equal(updatedCredit.CreditAmount, result.CreditAmount);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            CreditRepository creditRepository = new(_context);
            int id = 1;

            // Act
            var result = await creditRepository.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.DeletedAt);
        }
        #endregion
    }
}
