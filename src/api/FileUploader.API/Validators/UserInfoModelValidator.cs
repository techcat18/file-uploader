using FileUploader.API.Models;
using FluentValidation;

namespace FileUploader.API.Validators
{
    public class UserInfoModelValidator: AbstractValidator<UserInfoModel>
    {
        public UserInfoModelValidator()
        {
            RuleFor(ui => ui.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}