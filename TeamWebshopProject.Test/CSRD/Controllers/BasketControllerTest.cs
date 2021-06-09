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

namespace TeamWebshopProject.Test.CSRD.Controllers
{
    public class BasketControllerTest
    {
        private readonly BasketController _controller;
        private readonly Mock<IBasketService> basketService = new();

        public BasketControllerTest()
        {
            _controller = new BasketController(basketService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus200_WhenDataExists()
        {

        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus204_WhenNoDataExists()
        {

        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus500_WhenBasketIsNull()
        {

        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus400_WhenBasketSubmittedIsNull()
        {

        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus200_WhenBasketSubmitIsOk()
        {

        }

        [Fact]
        public async Task GetById_ShoudReturnWithBasket_WhenBasketExists()
        {
            
        }
    }
}
