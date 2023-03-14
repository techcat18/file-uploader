using FileUploader.API.Models;
using FluentValidation;

namespace FileUploader.API.Validators
{
    public class UserInfoModelValidator: AbstractValidator<UserInfoModel>
    {
        public UserInfoModelValidator()
        {
            RuleFor(ui => ui.Email)
                .NotEmpty().WithMessage("Email must not be empty")
                .EmailAddress().WithMessage("Email must be valid");
        }
    }
}