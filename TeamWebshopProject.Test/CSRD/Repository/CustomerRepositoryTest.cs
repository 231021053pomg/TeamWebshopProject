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
    public class CustomerRepositoryTest
    {
        #region setup
        private DbContextOptions<TeamWebshopDbContext> _options;
        private readonly TeamWebshopDbContext _context;

        public CustomerRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TeamWebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "CustomerItemDatabase")
                .Options;

            _context = new(_options);
            _context.Database.EnsureDeleted();
            _context.Add(new Customer
            {
                Id = 1,
                Login = new Login { Id = 1 },
                Credit = new Credit { Id = 1 },
                UserName = "LolGut89",
                FirstName = "Kurt",
                LastName = "Ko-Ben",
                BirthDay = new DateTime(1889, 04, 20),
                AddressStreet = "Testvej",
                AddressNumber = 1,
                AddressPostCode = 4000
            });
            _context.Add(new Customer
            {
                Id = 2,
                Login = new Login { Id = 2 },
                Credit = new Credit { Id = 2 },
                UserName = "KatteElsker93",
                FirstName = "Reltih",
                LastName = "Floda",
                BirthDay = new DateTime(1993, 04, 20),
                AddressStreet = "Testvej",
                AddressNumber = 2,
                AddressPostCode = 4000
            });
            _context.Add(new Customer
            {
                Id = 3,
                Login = new Login { Id = 3 },
                Credit = new Credit { Id = 3 },
                UserName = "KlunkeTogetFTW",
                FirstName = "Test",
                LastName = "Icle",
                BirthDay = new DateTime(0001, 04, 20),
                AddressStreet = "Testvej",
                AddressNumber = 3,
                AddressPostCode = 4000
            });
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedResult = 3;
            CustomerRepository customerRepository = new(_context);

            // Act
            var result = await customerRepository.GetAll();

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
            Customer expectedResult = new Customer
            {
                Id = 1,
                Login = new Login { Id = 1 },
                Credit = new Credit { Id = 1 },
                UserName = "LolGut89",
                FirstName = "Kurt",
                LastName = "Ko-Ben",
                BirthDay = new DateTime(1889, 04, 20),
                AddressStreet = "Testvej",
                AddressNumber = 1,
                AddressPostCode = 4000
            };
            CustomerRepository customerRepository = new(_context);

            // Act
            var result = await customerRepository.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.UserName, result.UserName);
            Assert.Equal(expectedResult.AddressPostCode, result.AddressPostCode);
            Assert.Equal(expectedResult.Login.Id, result.Login.Id);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Customer newCustomer = new Customer
            {
                Login = new Login { Id = 1 },
                Credit = new Credit { Id = 1 },
                UserName = "LolGut89",
                FirstName = "Kurt",
                LastName = "Ko-Ben",
                BirthDay = new DateTime(1889, 04, 20),
                AddressStreet = "Testvej",
                AddressNumber = 1,
                AddressPostCode = 4000
            };
            CustomerRepository customerRepository = new(_context);

            // Act
            var result = await customerRepository.Create(newCustomer);

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
            CustomerRepository customerRepository = new(_context);
            Customer updatedCustomer = new Customer
            {
                Id = 1,
                Login = new Login { Id = 1 },
                Credit = new Credit { Id = 1 },
                UserName = "TheShitKingBigBoiStyle",
                FirstName = "Kurt",
                LastName = "Ko-Ben",
                BirthDay = new DateTime(1889, 04, 20),
                AddressStreet = "Testvej",
                AddressNumber = 1,
                AddressPostCode = 4000
            };

            // Act
            var result = await customerRepository.Update(updatedCustomer.Id, updatedCustomer);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.EditedAt);
            Assert.Equal(updatedCustomer.UserName, result.UserName);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            CustomerRepository customerRepository = new(_context);
            int id = 1;

            // Act
            var result = await customerRepository.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.DeletedAt);
        }
        #endregion
    }
}
