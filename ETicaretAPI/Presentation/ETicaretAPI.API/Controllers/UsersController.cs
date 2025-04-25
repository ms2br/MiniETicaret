using ETicaretAPI.Application.Features.Commands.Register.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IMediator _mediator { get; }
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateUserCommonRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(new 
                {
                    errorMessage = ex.Message
                });
            }
        }
    }
}
