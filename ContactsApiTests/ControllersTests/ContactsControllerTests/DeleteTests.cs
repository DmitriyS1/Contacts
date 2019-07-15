using ContactsApi.Exeptions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ContactsApiTests.ControllersTests.ContactsControllerTests
{
    public class DeleteTests : ContactsTestFixture
    {
        [Fact]
        public async Task Should_ReturnNotFound_IfContactNotExists()
        {
            ContactsServiceMock
                .Setup(s => s.DeleteAsync(It.IsAny<ObjectId>()))
                .ThrowsAsync(new NotFoundException());

            var response = await ControllerMock.Delete("5d2b5b105c20853204e52c8a");

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task Should_ReturnOk()
        {
            ContactsServiceMock
                .Setup(s => s.DeleteAsync(It.IsAny<ObjectId>()))
                .Returns(Task.CompletedTask);

            var response = await ControllerMock.Delete("5d2b5b105c20853204e52c8a");

            Assert.IsType<OkResult>(response);
        }
    }
}
