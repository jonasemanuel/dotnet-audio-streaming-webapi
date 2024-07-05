using System.Security.Claims;
using AudioStreaming.Application;
using AudioStreaming.Domain;
using AudioStreaming.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Admin;

public class AccountController : Controller
{
  private readonly UserService _userService;
  public AccountController(UserService userService)
  {
      _userService = userService;
  }

  public IActionResult Login()
  {
      return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginUserDTO dto)
  {
      if(!ModelState.IsValid)
      {
          return RedirectToAction("Index");
      }
      User user = this._userService.Login(dto.Email, dto.Password);
      if(user == null)
      {
          return View();
      }

      var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
      identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
      identity.AddClaim(new Claim(ClaimTypes.Name, user.Email.Value));
      identity.AddClaim(new Claim(ClaimTypes.Email, user.Email.Value));

      await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

      return RedirectToAction("Index", "Home");
  }

  public async Task<IActionResult> Logout()
  {
      await HttpContext.SignOutAsync();
      return RedirectToAction("Index", "Home");
  }
}
