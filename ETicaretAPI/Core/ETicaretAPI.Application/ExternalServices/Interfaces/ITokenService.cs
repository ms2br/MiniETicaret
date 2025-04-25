using ETicaretAPI.Application.Dtos.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        TokenDto CreateAccessToken();
    }
}
