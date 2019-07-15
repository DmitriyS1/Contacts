using AutoMapper;
using ContactsApi.Controllers;
using ContactsApi.Dal.Repositories.Interfaces;
using Moq;
using Moq.AutoMock;

namespace ContactsApiTests
{
    public abstract class ContactsTestFixture
    {
        public AutoMocker Mocker { get; set; }

        public ContactsController ControllerMock { get; set; }

        public Mock<IContactsRepository> ContactsRepositoryMock { get; set; }

        public Mock<IMapper> MapperMock { get; set; }

        public ContactsTestFixture()
        {
            Mocker = new AutoMocker();
            ControllerMock = Mocker.CreateInstance<ContactsController>();
            ContactsRepositoryMock = Mocker.GetMock<IContactsRepository>();
            MapperMock = Mocker.GetMock<IMapper>();
        }
    }
}
