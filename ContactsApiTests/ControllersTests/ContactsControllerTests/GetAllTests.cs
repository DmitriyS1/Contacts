using Contacts.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ContactsApiTests.ControllersTests.ContactsControllerTests
{
    public class GetAllTests : ContactsTestFixture
    {
        [Fact]
        public async Task Should_ReturnOk_IfContactsListIsEmpty()
        {
            ContactsRepositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Contact>());

            var response = await ControllerMock.GetAll();

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Should_ReturnOk_IfContactsListIsNotEmpty()
        {
            var contacts = new List<Contact> { new Contact(), new Contact() };
            ContactsRepositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(contacts);

            var response = await ControllerMock.GetAll();

            Assert.IsType<OkObjectResult>(response);
        }
    }
}
