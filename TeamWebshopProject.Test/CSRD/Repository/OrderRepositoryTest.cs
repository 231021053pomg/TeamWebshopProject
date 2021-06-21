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
    public class OrderRepositoryTest
    {
        #region setup
        private DbContextOptions<TeamWebshopDbContext> _options;
        private readonly TeamWebshopDbContext _context;

        public OrderRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TeamWebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "OrderDatabase")
                .Options;

            _context = new(_options);
            _context.Database.EnsureDeleted();
            _context.Add(new Order
            {
                Id = 1,
                Customer = new Customer { Id = 1 },
                Price = 4.20m
            });
            _context.Add(new Order
            {
                Id = 2,
                Customer = new Customer { Id = 2 },
                Price = 69.69m
            });
            _context.Add(new Order
            {
                Id = 3,
                Customer = new Customer { Id = 3 },
                Price = 16.9m
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
            OrderRepository orderRepository = new(_context);

            // Act
            var result = await orderRepository.GetAll();

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
            Order expectedResult = new Order
            {
                Id = 1,
                Customer = new Customer { Id = 1 },
                Price = 4.20m
            };
            OrderRepository orderRepository = new(_context);

            // Act
            var result = await orderRepository.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.Price, result.Price);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Order newOrder = new Order
            {
                Customer = new Customer { Id = 4 },
                Price = 4.20m
            };
            OrderRepository orderRepository = new(_context);

            // Act
            var result = await orderRepository.Create(newOrder);

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
            OrderRepository orderRepository = new(_context);
            Order updatedOrder = new Order
            {
                Id = 1,
                Customer = new Customer { Id = 5 },
                Price = 6.9m
            };

            // Act
            var result = await orderRepository.Update(updatedOrder.Id, updatedOrder);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.EditedAt);
            Assert.Equal(updatedOrder.Price, result.Price);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            OrderRepository orderRepository = new(_context);
            int id = 1;

            // Act
            var result = await orderRepository.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.DeletedAt);
        }
        #endregion
    }
}
