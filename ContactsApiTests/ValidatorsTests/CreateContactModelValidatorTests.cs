using Contacts.DTO.Requests;
using ContactsApi.Validators;
using Xunit;

namespace ContactsApiTests.ValidatorsTests
{
    public class CreateContactModelValidatorTests
    {
        private readonly CreateContactModelValidator _validator;
        private readonly CreateContactModel _model;
        
        public CreateContactModelValidatorTests()
        {
            _validator = new CreateContactModelValidator();
            _model = new CreateContactModel { FirstName = "Jhon", Phone = "+79534316199" };
        }

        [Theory]
        [InlineData("")]
        [InlineData("asdawdadasd")]
        [InlineData("7361")]
        public void Should_HaveValidationErrorForPhone(string phone)
        {
            _model.Phone = phone;

            _validator.Validate(_model);
        }
    }
}
