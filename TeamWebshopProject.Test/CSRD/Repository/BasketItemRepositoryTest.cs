using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Classes;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;
using Xunit;

namespace TeamWebshopProject.Test.CSRD.Repository
{
    public class BasketItemRepositoryTest
    {
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
            BasketItem expectedResult = new BasketItem 
            { 
                Id = 1, 
                Basket = new Basket { Id = 1 },
                Item = new Item { Id = 5 },
                Quantity = 2
            };
            int id = 1;
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
            int expectedCount = 4;
            BasketItem newItem = new BasketItem { 
                Id = 10,
                Basket = new Basket { Id = 1 },
                Item = new Item { Id = 2 },
                Quantity = 2
            };
            BasketItemRepository basketItemRepository = new(_context);

            // Act
            var result = await basketItemRepository.Create(newItem);
            var getAll = await basketItemRepository.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, getAll.Count());
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
