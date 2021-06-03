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
    public class ItemRepositoryTest
    {
        #region setup
        private DbContextOptions<TeamWebshopDbContext> _options;
        private readonly TeamWebshopDbContext _context;

        public ItemRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TeamWebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "ItemDatabase")
                .Options;

            _context = new(_options);
            _context.Database.EnsureDeleted();
            _context.Add(new Item
            {
                Id = 1,
                ItemType = "Test",
                Price = 4.20m,
                Discount = 13.37m,
                Discription = "Test Item",
                Image = "image/1.png",
                Tags = { new Tag { Id = 1, Name = "Bruh" } }
            });
            _context.Add(new Item
            {
                Id = 2,
                ItemType = "Test",
                Price = 4.20m,
                Discount = 13.37m,
                Discription = "Test Item",
                Image = "image/2.png",
                Tags = { new Tag { Id = 1, Name = "Bruh" } }
            });
            _context.Add(new Item
            {
                Id = 3,
                ItemType = "Test",
                Price = 4.20m,
                Discount = 13.37m,
                Discription = "Test Item",
                Image = "image/3.png",
                Tags = { new Tag { Id = 1, Name = "Bruh" } }
            });
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedResult = 3;
            ItemRepository itemRepository = new(_context);

            // Act
            var result = await itemRepository.GetAll();

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
            Item expectedResult = new Item
            {
                Id = 1,
                ItemType = "Test",
                Price = 4.20m,
                Discount = 13.37m,
                Discription = "Test Item",
                Image = "image/1.png",
                Tags = { new Tag { Id = 1, Name = "Bruh" } }
            };
            ItemRepository itemRepository = new(_context);

            // Act
            var result = await itemRepository.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.Discription, result.Discription);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Item newItem = new Item
            {
                ItemType = "Test",
                Price = 4.20m,
                Discount = 13.37m,
                Discription = "Test Item",
                Image = "image/1.png",
                Tags = { new Tag { Id = 1, Name = "Bruh" } }
            };
            ItemRepository itemRepository = new(_context);

            // Act
            var result = await itemRepository.Create(newItem);

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
            ItemRepository itemRepository = new(_context);
            Item updatedItem = new Item
            {
                Id = 1,
                ItemType = "Test",
                Price = 4.20m,
                Discount = 13.37m,
                Discription = "Test Item, super kvali",
                Image = "image/1.png",
                Tags = { new Tag { Id = 1, Name = "Bruh" } }
            };

            // Act
            var result = await itemRepository.Update(updatedItem.Id, updatedItem);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.EditedAt);
            Assert.Equal(updatedItem.Discription, result.Discription);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            ItemRepository itemRepository = new(_context);
            int id = 1;

            // Act
            var result = await itemRepository.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.DeletedAt);
        }
        #endregion
    }
}
