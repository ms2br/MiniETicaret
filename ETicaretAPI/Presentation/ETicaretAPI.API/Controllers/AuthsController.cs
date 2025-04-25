using ETicaretAPI.Application.Features.Commands.Auths.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        public IMediator _mediator { get; }

        public AuthsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginUserCommonRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
