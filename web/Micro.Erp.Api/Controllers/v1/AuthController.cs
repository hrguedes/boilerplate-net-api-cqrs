using MediatR;
using Micro.Erp.Api.Services;
using Micro.Erp.Application.Users.Commands.requests;
using Micro.Erp.Application.Users.Commands.responses;
using Micro.Erp.Application.Users.Queries.Requests;
using Micro.Erp.Application.Users.Queries.Responses;
using Micro.Erp.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Erp.Api.Controllers.v1;


[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthController : BaseController
{
    public AuthController(NotificationContext notificationContext) : base(notificationContext)
    {
    }
    
    /// <summary>
    /// Auth user and return Token
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="command"></param>
    /// <remarks>
    /// POST /api/v1/Auth/login
    /// </remarks>
    /// <returns> user and Token </returns>
    /// <response code="200">user and Token</response>
    /// <response code="400">Client Error</response>
    /// <response code="500">Server Error (Contact Admin)</response>
    [HttpPost("login")]
    [ApiExplorerSettings(GroupName = "Auth")]
    [ProducesResponseType(typeof(UserAutenticated), 200)]
    [ProducesResponseType(typeof(UserAutenticated), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> AuthUser(
        [FromServices] IMediator mediator,
        [FromBody] AutenticateUser command
    )
    {
        var resp = await mediator.Send(command);
        if (resp != null)
        {
            var jwtToken = await new IdentityTokenService().GenerateToken(resp);
            resp.Token = jwtToken;
        }
        return StatusCode(200, resp);
    }
    
    /// <summary>
    /// Return info about user authenticated
    /// </summary>
    /// <param name="mediator"></param>
    /// <remarks>
    /// POST /api/v1/Auth/isAuthenticated
    /// </remarks>
    /// <returns> user and Token </returns>
    /// <response code="200">user name and Token</response>
    /// <response code="400">Client Error</response>
    /// <response code="500">Server Error (Contact Admin)</response>
    [Authorize]
    [HttpGet("logged-user")]
    [ApiExplorerSettings(GroupName = "Auth")]
    [ProducesResponseType(typeof(UserResponse), 200)]
    [ProducesResponseType(typeof(UserResponse), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> UserIsAutenticated(
        [FromServices] IMediator mediator
        )
    {
        var resp = await mediator.Send(new GetUserById()
        {
            Id = UsuarioId
        });
        return StatusCode(200, resp);
    }
    
}