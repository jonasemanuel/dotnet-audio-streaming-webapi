using AudioStreaming.Application;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Http;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _userService;

    public AuthController(AuthService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Cadaster([FromBody] CadasterUserDTO request)
    {
        if(ModelState.IsValid == false) return BadRequest(ModelState);
        
        _userService.Create(request);
        return Ok();
    }

    [HttpGet]
    public IActionResult Login([FromBody] LoginUserDTO request)
    {
        return Ok(_userService.Authenticate(email: request.Email, password: request.Password));
    }
}
