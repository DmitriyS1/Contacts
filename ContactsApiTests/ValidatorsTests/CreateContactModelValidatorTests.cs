using Contacts.DTO.Requests;
using ContactsApi.Validators;
using FluentValidation.TestHelper;
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

            _validator.ShouldHaveValidationErrorFor(m => m.Phone, _model);
        }

        [Theory]
        [InlineData("")]
        [InlineData("asdawdadasd")]
        [InlineData("7361")]
        public void Should_HaveValidationErrorForWorkPhone(string workPhone)
        {
            _model.WorkPhone = workPhone;

            _validator.ShouldHaveValidationErrorFor(m => m.WorkPhone, _model);
        }

        [Fact]
        public void Should_NotHaveValidationError()
        {
            _model.FirstName = "Jhon";
            _model.Phone = "+79923451677";
            _model.WorkPhone = "89923451677";

            _validator.TestValidate(_model);
        }
    }
}
