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
    public class TagRepositoryTest
    {
        #region setup
        private DbContextOptions<TeamWebshopDbContext> _options;
        private readonly TeamWebshopDbContext _context;

        public TagRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TeamWebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "TagDatabase")
                .Options;

            _context = new(_options);
            _context.Database.EnsureDeleted();
            _context.Add(new Tag
            {
                Id = 1,
                Name = "NSFW"
            });
            _context.Add(new Tag
            {
                Id = 2,
                Name = "Funny"
            });
            _context.Add(new Tag
            {
                Id = 3,
                Name = "Deepfried"
            });
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedResult = 3;
            TagRepository tagRepository = new(_context);

            // Act
            var result = await tagRepository.GetAll();

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
            Tag expectedResult = new Tag
            {
                Id = 1,
                Name = "NSFW"
            };
            TagRepository tagRepository = new(_context);

            // Act
            var result = await tagRepository.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.Name, result.Name);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Tag newTag = new Tag
            {
                Name = "SFW"
            };
            TagRepository tagRepository = new(_context);

            // Act
            var result = await tagRepository.Create(newTag);

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
            TagRepository tagRepository = new(_context);
            Tag updatedTag = new Tag
            {
                Name = "Stupid"
            };

            // Act
            var result = await tagRepository.Update(updatedTag.Id, updatedTag);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.EditedAt);
            Assert.Equal(updatedTag.Name, result.Name);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            TagRepository tagRepository = new(_context);
            int id = 1;

            // Act
            var result = await tagRepository.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(DateTime.MinValue, result.DeletedAt);
        }
        #endregion
    }
}
