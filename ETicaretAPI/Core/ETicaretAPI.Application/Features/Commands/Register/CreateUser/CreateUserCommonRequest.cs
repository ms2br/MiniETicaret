using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Register.CreateUser
{
    public class CreateUserCommonRequest : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }

    public class CreateUserCommonRequestValidation : AbstractValidator<CreateUserCommonRequest>
    {
        public CreateUserCommonRequestValidation()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(48)
                .MinimumLength(3)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.LastName)
                .MaximumLength(48)
                .MinimumLength(3)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .Matches("^(?=\\S*[A-Z])(?=\\S*[a-z])(?=\\S*[0-9])(?=\\S*[!@#$%^&*])\\S{6,}$")
                .WithMessage("Password must be at least 6 characters and include uppercase letters, lowercase letters, numbers and special characters.");

            RuleFor(x => x)
                .NotEmpty()
                .NotNull()
                .Must(model => model.Password == model.RepeatPassword)
                .WithMessage("Password and password repetition must be the same");
        }
    }
}
