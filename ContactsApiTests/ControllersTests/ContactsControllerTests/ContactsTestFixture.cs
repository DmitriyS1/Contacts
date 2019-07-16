using AutoMapper;
using ContactsApi.Controllers;
using ContactsApi.Dal.Repositories.Interfaces;
using ContactsApi.Services;
using Moq;
using Moq.AutoMock;

namespace ContactsApiTests.ControllersTests.ContactsControllerTests
{
    public abstract class ContactsTestFixture
    {
        public AutoMocker Mocker { get; set; }

        public ContactsController ControllerMock { get; set; }

        public Mock<IContactsRepository> ContactsRepositoryMock { get; set; }

        public Mock<IContactsService> ContactsServiceMock { get; set; }

        public Mock<IMapper> MapperMock { get; set; }

        public ContactsTestFixture()
        {
            Mocker = new AutoMocker();
            ControllerMock = Mocker.CreateInstance<ContactsController>();
            ContactsRepositoryMock = Mocker.GetMock<IContactsRepository>();
            ContactsServiceMock = Mocker.GetMock<IContactsService>();
            MapperMock = Mocker.GetMock<IMapper>();
        }
    }
}
