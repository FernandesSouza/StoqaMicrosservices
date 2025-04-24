using Microsoft.AspNetCore.Mvc;
using Stoqa.Identity.ApplicationService.DTOs.UserDtos.Request;
using Stoqa.Identity.ApplicationService.DTOs.UserDtos.Response;
using Stoqa.Identity.ApplicationService.Interfaces.ServiceContracts;

namespace Stoqa.Identity.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UserController(
    IUserCommandService commandService,
    IUserQueryService queryService
) : ControllerBase
{
    [HttpPost("user_register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<bool> Register([FromBody] UserRegisterRequest request) =>
        await commandService.RegisterAsync(request);

    [HttpGet("find_by_email")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<UserSimpleResponse?> FIndByEmail([FromQuery] string email) =>
        await queryService.FindByEmailAsync(email);
}