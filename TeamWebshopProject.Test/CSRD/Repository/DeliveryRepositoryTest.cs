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
    public class DeliveryRepositoryTest
    {
        #region setup
        private DbContextOptions<TeamWebshopDbContext> _options;
        private readonly TeamWebshopDbContext _context;

        public DeliveryRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TeamWebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "DeliveryDatabase")
                .Options;

            _context = new(_options);
            _context.Database.EnsureDeleted();
            _context.Add(new Delivery
            {
                Id = 1,
                Order = new Order { Id = 1 },
                Status = "Problem with delivery"
            });
            _context.Add(new Delivery
            {
                Id = 2,
                Order = new Order { Id = 2 },
                Status = "Problem with delivery"
            });
            _context.Add(new Delivery
            {
                Id = 3,
                Order = new Order { Id = 3 },
                Status = "Problem with delivery"
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
            DeliveryRepository deliveryRepository = new(_context);

            // Act
            var result = await deliveryRepository.GetAll();

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
            Delivery expectedResult = new Delivery
            {
                Id = 1,
                Order = new Order { Id = 1 },
                Status = "Problem with delivery"
            };
            DeliveryRepository deliveryRepository = new(_context);

            // Act
            var result = await deliveryRepository.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.Status, result.Status);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Delivery newDelivery = new Delivery
            {
                Order = new Order { Id = 10 },
                Status = "Lol nej"
            };
            DeliveryRepository deliveryRepository = new(_context);

            // Act
            var result = await deliveryRepository.Create(newDelivery);

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
            DeliveryRepository deliveryRepository = new(_context);
            Delivery updatedDelivery = new Delivery
            {
                Id = 1,
                Order = new Order { Id = 1 },
                Status = "Order now shipped"
            };

            // Act
            var result = await deliveryRepository.Update(updatedDelivery.Id, updatedDelivery);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.EditedAt);
            Assert.Equal(updatedDelivery.Status, result.Status);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            DeliveryRepository deliveryRepository = new(_context);
            int id = 1;

            // Act
            var result = await deliveryRepository.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.DeletedAt);
        }
        #endregion
    }
}
