using Contacts.Core.Entities;
using Contacts.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ContactsApiTests.ControllersTests.ContactsControllerTests
{
    public class PostTests : ContactsTestFixture
    {
        [Fact]
        public async Task Should_ReturnUnprocessableEntity_IfModelIsNotValid()
        {
            ControllerMock.ModelState.AddModelError("test", "error");

            var response = await ControllerMock.Post(It.IsAny<CreateContactModel>());

            Assert.IsType<UnprocessableEntityResult>(response);
        }

        [Fact]
        public async Task Should_ReturnOk()
        {
            MapperMock
                .Setup(m => m.Map<Contact>(It.IsAny<CreateContactModel>()))
                .Returns(new Contact());
            ContactsRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<Contact>()))
                .Returns(Task.CompletedTask);

            var response = await ControllerMock.Post(It.IsAny<CreateContactModel>());

            Assert.IsType<OkResult>(response);
        }
    }
}
