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
    public class BasketRepositoryTest
    {
        #region setup
        private DbContextOptions<TeamWebshopDbContext> _options;
        private readonly TeamWebshopDbContext _context;

        public BasketRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TeamWebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "BasketItemDatabase")
                .Options;

            _context = new(_options);
            _context.Database.EnsureDeleted();
            _context.Add(new Basket
            {
                Customer = new Customer { Id = 1 },
                Quantity = 4,
                Price = 18.6m,
                Created = DateTime.MinValue
            });
            _context.Add(new Basket
            {
                Customer = new Customer { Id = 2 },
                Quantity = 5,
                Price = 666.6m,
                Created = DateTime.Today
            });
            _context.Add(new Basket
            {
                Customer = new Customer { Id = 3 },
                Quantity = 7,
                Price = 3000.6m,
                Created = DateTime.Now
            });
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedResult = 3;
            BasketRepository basketRepository = new(_context);

            // Act
            var result = await basketRepository.GetAll();

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
            Basket expectedResult = new Basket
            {
                Id = 1,
                Quantity = 4,
                Price = 18.6m,
                Created = DateTime.MinValue
            };
            BasketRepository basketRepository = new(_context);

            // Act
            var result = await basketRepository.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.Quantity, result.Quantity);
            Assert.Equal(expectedResult.Price, result.Price);
            Assert.Equal(expectedResult.Created, result.Created);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Basket newBasket = new Basket
            {
                Quantity = 4,
                Price = 20.2m,
                Created = DateTime.Now
            };
            BasketRepository basketRepository = new(_context);

            // Act
            var result = await basketRepository.Create(newBasket);

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
            BasketRepository basketRepository = new(_context);
            Basket updatedBasket = new Basket
            {
                Id = 1,
                Quantity = 9000,
                Price = 77.7m,
                Created = new DateTime(1996, 08, 20)
            };

            // Act
            var result = await basketRepository.Update(updatedBasket.Id, updatedBasket);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.EditedAt);
            Assert.Equal(updatedBasket.Quantity, result.Quantity);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            BasketRepository basketRepository = new(_context);
            int id = 1;

            // Act
            var result = await basketRepository.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.DeletedAt);
        }
        #endregion
    }
}
