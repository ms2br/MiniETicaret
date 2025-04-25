using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Register.CreateUser
{
    public class CreateUserCommonHandler : IRequestHandler<CreateUserCommonRequest>
    {
        UserManager<AppUser> _um { get; set; }

        public CreateUserCommonHandler(UserManager<AppUser> um)
        {
            _um = um;
        }

        public async Task Handle(CreateUserCommonRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _um.CreateAsync(new AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = $"{request.FirstName}  {request.LastName}",
            }, request.Password);
            if (!result.Succeeded)
            {
                StringBuilder builder = new StringBuilder();
                foreach (IdentityError error in result.Errors)
                {
                    builder.Append(error.Description + " ");
                }
                throw new UserCreateFailedException(builder.ToString()
                    .TrimEnd());
            }
        }
    }
}
