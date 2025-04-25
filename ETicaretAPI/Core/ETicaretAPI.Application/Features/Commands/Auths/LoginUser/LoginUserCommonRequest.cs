using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Auths.LoginUser
{
    public class LoginUserCommonRequest : IRequest<LoginUserCommonResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommonRequestValidation : AbstractValidator<LoginUserCommonRequest>
    {
        public LoginUserCommonRequestValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MaximumLength(255);

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .Matches("^(?=\\S*[A-Z])(?=\\S*[a-z])(?=\\S*[0-9])(?=\\S*[!@#$%^&*])\\S{6,}$")
                 .WithMessage("Password must be at least 6 characters and include uppercase letters, lowercase letters, numbers and special characters."); ;
        }
    }
}
