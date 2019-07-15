using Contacts.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ContactsApiTests
{
    public class GetTests : ContactsTestFixture
    {
        [Fact]
        public async Task Should_ReturnOk()
        {
            ContactsRepositoryMock
                .Setup(cr => cr.GetAsync(It.IsAny<ObjectId>()))
                .ReturnsAsync(new Contact());

            var response = await ControllerMock.Get("5d2b5b105c20853204e52c8a");

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Should_ReturnNotFound_IfContactNotExists()
        {
            ContactsRepositoryMock
                .Setup(cr => cr.GetAsync(It.IsAny<ObjectId>()))
                .ReturnsAsync(() => null);

            var response = await ControllerMock.Get("5d2b5b105c20853204e52c8a");

            Assert.IsType<NotFoundResult>(response);
        }
    }
}
