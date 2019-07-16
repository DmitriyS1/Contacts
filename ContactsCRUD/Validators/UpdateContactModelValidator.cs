using Contacts.DTO.Requests;
using FluentValidation;

namespace ContactsApi.Validators
{
    public class UpdateContactModelValidator : AbstractValidator<UpdateContactModel>
    {
        public UpdateContactModelValidator()
        {
            RuleFor(m => m.FirstName).MaximumLength(256);
            RuleFor(m => m.Phone).Matches("^((\\+7|7|8)+([0-9]){10})$")
                .WithMessage("Invalid phone number");
            RuleFor(m => m.WorkPhone).Matches("^((\\+7|7|8)+([0-9]){10})$")
                .WithMessage("Invalid work phone number");
        }
    }
}
