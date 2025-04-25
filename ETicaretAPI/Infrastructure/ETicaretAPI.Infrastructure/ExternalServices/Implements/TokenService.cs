using ETicaretAPI.Application.Dtos.Jwt;
using ETicaretAPI.Application.ExternalServices.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ETicaretAPI.Infrastructure.ExternalServices.Implements
{
    public class TokenService : ITokenService
    {
        Jwt _jwtOptions { get; }

        public TokenService(IOptionsMonitor<Jwt> jwtOptions)
        {
            _jwtOptions = jwtOptions.CurrentValue;

        }

        public TokenDto CreateAccessToken()
        {
            TokenDto token = new();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SigningKey));

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new(
                audience: _jwtOptions.Audience,
                issuer: _jwtOptions.Issuer,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ValidityMinute),
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
