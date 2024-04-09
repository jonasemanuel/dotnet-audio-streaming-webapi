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
    [Route("cadaster")]
    public IActionResult Cadaster([FromBody] CadasterUserDTO request)
    {
        if(ModelState.IsValid == false) return BadRequest(ModelState);
        
        _userService.Create(request);
        return Ok();
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] LoginUserDTO request)
    {
        var user = _userService.Authenticate(email: request.Email, password: request.Password);
        if(user == null) return Unauthorized();
        return Ok(user);
    }
}
