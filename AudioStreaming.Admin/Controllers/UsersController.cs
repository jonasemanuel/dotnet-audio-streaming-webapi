using AudioStreaming.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Admin;

[Authorize]
public class UsersController : Controller
{
    private readonly UserService _userService;
    public UsersController(UserService userService)
    {
        _userService = userService;
    }
    public IActionResult Index()
    {
        var albums = _userService.GetAll();
        return View(albums);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Save(RequestCreateUserDTO dto)
    {
        if(!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }
        this._userService.Create(dto);
        return RedirectToAction("Index");
    }
}
