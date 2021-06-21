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
    public class LoginRepositoryTest
    {
        #region setup
        private DbContextOptions<TeamWebshopDbContext> _options;
        private readonly TeamWebshopDbContext _context;

        public LoginRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TeamWebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "LoginDatabase")
                .Options;

            _context = new(_options);
            _context.Database.EnsureDeleted();
            _context.Add(new Login
            {
                Id = 1,
                AccessType = "Admin",
                Email = "BoigBoi@yahoo.dk",
                Password = "PassW0rd"
            });
            _context.Add(new Login
            {
                Id = 2,
                AccessType = "Admin",
                Email = "BoigBoi@yahoo.com",
                Password = "PassW0rd"
            });
            _context.Add(new Login
            {
                Id = 3,
                AccessType = "User",
                Email = "BoigBoi@hotmail.com",
                Password = "PassW0rd"
            });
            _context.SaveChanges();
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedResult = 3;
            LoginRepository loginRepository = new(_context);

            // Act
            var result = await loginRepository.GetAll();

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
            Login expectedResult = new Login
            {
                Id = 1,
                AccessType = "Admin",
                Email = "BoigBoi@yahoo.dk",
                Password = "PassW0rd"
            };
            LoginRepository loginRepository = new(_context);

            // Act
            var result = await loginRepository.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.Email, result.Email);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Login newLogin = new Login
            {
                AccessType = "Admin",
                Email = "BoigBoi@yahoo.dk",
                Password = "PassW0rd"
            };
            LoginRepository loginRepository = new(_context);

            // Act
            var result = await loginRepository.Create(newLogin);

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
            LoginRepository loginRepository = new(_context);
            Login updatedLogin = new Login
            {
                Id = 1,
                AccessType = "Admin",
                Email = "BoigBoi@yahoo.dk",
                Password = "BigBootyBitches"
            };

            // Act
            var result = await loginRepository.Update(updatedLogin.Id, updatedLogin);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.EditedAt);
            Assert.Equal(updatedLogin.Password, result.Password);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            LoginRepository loginRepository = new(_context);
            int id = 1;

            // Act
            var result = await loginRepository.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.DeletedAt);
        }
        #endregion
    }
}
