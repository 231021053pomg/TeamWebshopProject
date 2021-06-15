using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Moq;

using TeamWebshopProject.API.CSRD.Controllers;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.Test.CSRD.Controllers
{
    public class ItemControllerTest
    {
        private readonly ItemController _controller;
        private readonly Mock<IItemService> itemService = new();

        public ItemControllerTest()
        {
            _controller = new ItemController(itemService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus200_WhenDataExists()
        {
            // Arrange
            List<Item> items = new List<Item>();
            items.Add(new Item());
            items.Add(new Item());

            itemService
                .Setup(s => s.GetAll())
                .ReturnsAsync(items);

            // Act
            var result = await _controller.GetAll();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus204_WhenNoDataExists()
        {
            // Arrange
            List<Item> items = new List<Item>();

            itemService
                .Setup(s => s.GetAll())
                .ReturnsAsync(items);

            // Act
            var result = await _controller.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus500_WhenItemIsNull()
        {
            //Arrange
            List<Item> items = null;

            itemService
                .Setup(s => s.GetAll())
                .ReturnsAsync(items);
            //Act
            var result = await _controller.GetAll();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus400_WhenItemSubmittedIsNull()
        {
            // Arrange
            Item item = null;

            itemService
                .Setup(s => s.Create(null))
                .ReturnsAsync(item);
            // Act
            var response = await _controller.Create(item);
            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus200_WhenItemSubmitIsOk()
        {
            // Arrange
            Item item = new Item { ItemType = "", Price = 0, Discount = 0, Discription = "", Image = "" };
            itemService
                .Setup(s => s.Create(It.IsAny<Item>()))
                .ReturnsAsync(item);
            // Act
            var respone = await _controller.Create(item);

            // Assert
            var responeStatusCode = (IStatusCodeActionResult)respone;
            Assert.Equal(200, responeStatusCode.StatusCode);
        }

        [Fact]
        public async Task GetById_ShoudReturnWithBasket_WhenItemExists()
        {
            // Arrange
            int id = 1;
            decimal price = 0;
            decimal discount =0;
            string itemtype = "";
            string discripton = "";
            string image = "";



            Item item = new Item
            {
                Id = id,
                Price = price,
                Discount = discount,
                ItemType = itemtype,
                Discription = discripton,
                Image = image

            };

            itemService
                .Setup(s => s.Get(It.IsAny<int>()))
                .ReturnsAsync(item);
            // Act
            var respone = await _controller.Get(id);
            // Assert
            Assert.NotNull(respone);
        }
    }
}
