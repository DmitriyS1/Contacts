using Contacts.DTO.Requests;
using ContactsApi.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace ContactsApiTests.ValidatorsTests
{
    public class UpdateContactModelValidatorTests
    {
        private readonly UpdateContactModelValidator _validator;
        private readonly UpdateContactModel _model;

        public UpdateContactModelValidatorTests()
        {
            _validator = new UpdateContactModelValidator();
            _model = new UpdateContactModel();
        }

        [Theory]
        [InlineData("")]
        [InlineData("83247")]
        [InlineData("fgdfgdfgj")]
        [InlineData("     ")]
        public void Should_HaveValidationError_IfPhoneIsNotValid(string phone)
        {
            _model.Phone = phone;

            _validator.ShouldHaveValidationErrorFor(m => m.Phone, _model);
        }

        [Theory]
        [InlineData("")]
        [InlineData("83247")]
        [InlineData("fgdfgdfgj")]
        [InlineData("     ")]
        public void Should_HaveValidationError_IfWorkPhoneIsNotValid(string workPhone)
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
