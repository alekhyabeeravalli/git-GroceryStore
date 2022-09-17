
using AutoFixture;
using GroceryStore.Controllers;
using GroceryStore.Core.User;
using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MsUnitTest
{
    [TestClass]
    public class GroceryTest
    {
        private Mock<IGroceryItems> _groceryRepoMock;
        private Fixture _fixture;
        private GroceryItemModelController _controller;
        public GroceryTest()
        {
            _fixture = new Fixture();
            _groceryRepoMock = new Mock<IGroceryItems>();
        }
        [TestMethod]

        public async Task GetGroceryReturnOk()
        {
            var groceryList = _fixture.CreateMany<GroceryItemModel>(3).ToList();
            _groceryRepoMock.Setup(repo => repo.GetGroceryItems()).Returns(groceryList);
            _controller = new GroceryItemModelController(_groceryRepoMock.Object);
            var result = await _controller.GetGroceryItems();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]

        public async Task GetGroceryThrowException()
        {
            _groceryRepoMock.Setup(repo => repo.GetGroceryItems()).Throws(new Exception());
            _controller = new GroceryItemModelController(_groceryRepoMock.Object);
            var result = await _controller.GetGroceryItems();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]

        public async Task AddGroceryReturnOk()
        {
            var grocery = _fixture.Create<GroceryItemModel>();
            _groceryRepoMock.Setup(repo => repo.AddGrocery(It.IsAny<GroceryItemModel>())).Returns(grocery);
            _controller = new GroceryItemModelController(_groceryRepoMock.Object);
            var result = await _controller.AddGrocery(grocery);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]

        public async Task AddGroceryThrowException()
        {
            var grocery = _fixture.Create<GroceryItemModel>();
            _groceryRepoMock.Setup(repo => repo.AddGrocery(It.IsAny<GroceryItemModel>())).Throws(new Exception());
            _controller = new GroceryItemModelController(_groceryRepoMock.Object);
            var result = await _controller.AddGrocery(grocery);
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]

        public async Task UpdateGroceryReturnOk()
        {
            var grocery = _fixture.Create<GroceryItemModel>();
            _groceryRepoMock.Setup(repo => repo.UpdateGrocery(It.IsAny<GroceryItemModel>())).Returns(grocery);
            _controller = new GroceryItemModelController(_groceryRepoMock.Object);
            var result = await _controller.UpdateGrocery(grocery);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]

        public async Task UpdateGroceryThrowException()
        {
            var grocery = _fixture.Create<GroceryItemModel>();
            _groceryRepoMock.Setup(repo => repo.UpdateGrocery(It.IsAny<GroceryItemModel>())).Throws(new Exception());
            _controller = new GroceryItemModelController(_groceryRepoMock.Object);
            var result = await _controller.UpdateGrocery(grocery);
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]

        public async Task DeleteGroceryReturnOk()
        {
            var grocery = _fixture.Create<GroceryItemModel>();
            _groceryRepoMock.Setup(repo => repo.DeleteGrocery(It.IsAny<int>())).Returns(grocery);
            _controller = new GroceryItemModelController(_groceryRepoMock.Object);
            var result = await _controller.DeleteGrocery(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]

        public async Task DeleteGroceryThrowException()
        {
            var grocery = _fixture.Create<GroceryItemModel>();
            _groceryRepoMock.Setup(repo => repo.DeleteGrocery(It.IsAny<int>())).Throws(new Exception());
            _controller = new GroceryItemModelController(_groceryRepoMock.Object);
            var result = await _controller.DeleteGrocery(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
    }
}


