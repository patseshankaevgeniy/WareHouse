using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WareHouse.Application.Auth;
using WareHouse.Application.Auth.Models;
using WareHouse.Application.Common.Models;

namespace WareHouse.Api.Controllers;

[ApiController]
[Route("api/auth")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("signIn", Name = "SignIn")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SignInResultDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
    public async Task<ActionResult<SignInResultDto>> SignInAsync(SignInDto signInDto)
    {
        var signInResultDto = await _authService.SignInAsync(signInDto);
        return Ok(signInResultDto);
    }

    [HttpPost("signUp", Name = "SignUp")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SignInResultDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
    public async Task<ActionResult<SignUpResultDto>> SignUpAsync(SignUpDto signUpDto)
    {
        var signUpResultDto = await _authService.SignUpAsync(signUpDto);
        return Ok(signUpResultDto);
    }
}
