using ETicaretAPI.Application.Dtos.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Auths.LoginUser
{
    public class LoginUserCommonResponse
    {
        public TokenDto Token { get; set; }
    }
}
