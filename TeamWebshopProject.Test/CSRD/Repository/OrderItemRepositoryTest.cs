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
    public class OrderItemRepositoryTest
    {
        #region setup
        private DbContextOptions<TeamWebshopDbContext> _options;
        private readonly TeamWebshopDbContext _context;

        public OrderItemRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TeamWebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "OrderItemDatabase")
                .Options;

            _context = new(_options);
            _context.Database.EnsureDeleted();
            _context.Add(new OrderItem
            {
                Id = 1,
                Order = new Order { Id = 1 },
                Item = new Item { Id = 1 },
                Quantity = 1
            });
            _context.Add(new OrderItem
            {
                Id = 2,
                Order = new Order { Id = 2 },
                Item = new Item { Id = 2 },
                Quantity = 2
            });
            _context.Add(new OrderItem
            {
                Id = 3,
                Order = new Order { Id = 3 },
                Item = new Item { Id = 3 },
                Quantity = 3
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
            OrderItemRepository orderItemRepository = new(_context);

            // Act
            var result = await orderItemRepository.GetAll();

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
            OrderItem expectedResult = new OrderItem
            {
                Id = 1,
                Order = new Order { Id = 1 },
                Item = new Item { Id = 1 },
                Quantity = 1
            };
            OrderItemRepository orderItemRepository = new(_context);

            // Act
            var result = await orderItemRepository.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.Quantity, result.Quantity);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            OrderItem newOrderItem = new OrderItem
            {
                Order = new Order { Id = 1 },
                Item = new Item { Id = 1 },
                Quantity = 1
            };
            OrderItemRepository orderItemRepository = new(_context);

            // Act
            var result = await orderItemRepository.Create(newOrderItem);

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
            OrderItemRepository orderItemRepository = new(_context);
            OrderItem updatedOrderItem = new OrderItem
            {
                Id = 1,
                Order = new Order { Id = 1 },
                Item = new Item { Id = 1 },
                Quantity = 5
            };

            // Act
            var result = await orderItemRepository.Update(updatedOrderItem.Id, updatedOrderItem);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.EditedAt);
            Assert.Equal(updatedOrderItem.Quantity, result.Quantity);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            OrderItemRepository orderItemRepository = new(_context);
            int id = 1;

            // Act
            var result = await orderItemRepository.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.DeletedAt);
        }
        #endregion
    }
}
