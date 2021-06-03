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
    public class BasketItemRepositoryTest
    {
        #region setup
        private DbContextOptions<TeamWebshopDbContext> _options;
        private readonly TeamWebshopDbContext _context;

        public BasketItemRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TeamWebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "BasketItemDatabase")
                .Options;

            _context = new(_options);
            _context.Database.EnsureDeleted();
            _context.Add(
                new BasketItem
                {
                    Id = 1,
                    Basket = new Basket { Id = 1 },
                    Item = new Item { Id = 5 },
                    Quantity = 2
                });
            _context.Add(
                new BasketItem
                {
                    Id = 3,
                    Basket = new Basket { Id = 1 },
                    Item = new Item { Id = 4 },
                    Quantity = 9
                });
            _context.Add(
                new BasketItem
                {
                    Id = 8,
                    Basket = new Basket { Id = 3 },
                    Item = new Item { Id = 5 },
                    Quantity = 1
                });
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_ReturnSuccess_Test()
        {
            // Arrange
            int expectedResult = 3;
            BasketItemRepository basketItemRepository = new(_context);

            // Act
            var result = await basketItemRepository.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Count());
        }
        #endregion

        #region Get
        [Fact]
        public async Task Get_ReturnSuccess_Test()
        {
            // Arrange
            int id = 1;
            BasketItem expectedResult = new BasketItem
            {
                Id = id,
                Basket = new Basket { Id = 1 },
                Item = new Item { Id = 5 },
                Quantity = 2
            };
            BasketItemRepository basketItemRepository = new(_context);

            // Act
            var result = await basketItemRepository.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.Basket.Id, result.Basket.Id);
            Assert.Equal(expectedResult.Item.Id, result.Item.Id);
            Assert.Equal(expectedResult.Quantity, result.Quantity);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            BasketItem newItem = new BasketItem
            {
                Id = 10,
                Basket = new Basket { Id = 1 },
                Item = new Item { Id = 2 },
                Quantity = 2
            };
            BasketItemRepository basketItemRepository = new(_context);

            // Act
            var result = await basketItemRepository.Create(newItem);

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
            BasketItemRepository basketItemRepository = new(_context);
            BasketItem updatedBasketItem = new BasketItem
            {
                Id = 1,
                Basket = new Basket { Id = 1 },
                Item = new Item { Id = 5 },
                Quantity = 9000
            };

            // Act
            var result = await basketItemRepository.Update(updatedBasketItem.Id, updatedBasketItem);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.EditedAt);
            Assert.Equal(updatedBasketItem.Quantity, result.Quantity);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            BasketItemRepository basketItemRepository = new(_context);
            int id = 1;

            // Act
            var result = await basketItemRepository.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.DeletedAt);
        }
        #endregion
    }
}
