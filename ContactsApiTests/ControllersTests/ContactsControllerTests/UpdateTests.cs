using Contacts.DTO.Requests;
using ContactsApi.Exeptions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ContactsApiTests.ControllersTests.ContactsControllerTests
{
    public class UpdateTests : ContactsTestFixture
    {
        [Fact]
        public async Task Should_ReturnUnprocessableEntity_IfModelIsNotValid()
        {
            ControllerMock.ModelState.AddModelError("test", "error");

            var response = await ControllerMock.Update(It.IsNotNull<string>(), It.IsAny<UpdateContactModel>());

            Assert.IsType<UnprocessableEntityResult>(response);
        }

        [Fact]
        public async Task Should_ReturnNotFound_IfContactNotExists()
        {
            ContactsServiceMock
                .Setup(r => r.UpdateAsync(It.IsAny<ObjectId>(), It.IsAny<UpdateContactModel>()))
                .ThrowsAsync(new NotFoundException());

            var response = await ControllerMock.Update("5d2b5b105c20853204e52c8a", It.IsAny<UpdateContactModel>());

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task Should_ReturnOk()
        {
            ContactsServiceMock
                .Setup(r => r.UpdateAsync(It.IsAny<ObjectId>(), It.IsAny<UpdateContactModel>()))
                .ReturnsAsync(new ObjectId());

            var response = await ControllerMock.Update("5d2b5b105c20853204e52c8a", It.IsAny<UpdateContactModel>());

            Assert.IsType<OkObjectResult>(response);
        }
    }
}
