using FluentValidation;
using yume_api.src.repository.entities;


namespace yume_api.src.valodator.concret
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("The email cant't be empty")
                .EmailAddress();
        }
    }
}