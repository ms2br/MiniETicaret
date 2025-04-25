using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.ExternalServices.Interfaces;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Auths.LoginUser
{
    public class LoginUserCommonHandler : IRequestHandler<LoginUserCommonRequest, LoginUserCommonResponse>
    {

        UserManager<AppUser> _um { get; }
        SignInManager<AppUser> _sm { get; }
        ITokenService _tk { get; }

        public LoginUserCommonHandler(UserManager<AppUser> um, SignInManager<AppUser> sm, ITokenService tk)
        {
            _um = um;
            _sm = sm;
            _tk = tk;
        }

        public async Task<LoginUserCommonResponse> Handle(LoginUserCommonRequest request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _um.FindByEmailAsync(request.Email);
            if (appUser == null)
                throw new UserNotFoundException();
            SignInResult result = await _sm.CheckPasswordSignInAsync(appUser, request.Password, true);

            if (!result.Succeeded)
                throw new UserNotFoundException();

            return new()
            {
                Token = _tk.CreateAccessToken()
            };
        }
    }
}
