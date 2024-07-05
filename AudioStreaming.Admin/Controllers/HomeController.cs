using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AudioStreaming.Admin.Models;
using AudioStreaming.Application;
using Microsoft.AspNetCore.Authorization;

namespace AudioStreaming.Admin.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly MusicService _musicService;
    private readonly ArtistService _artistService;
    public HomeController(MusicService musicService, ArtistService artistService)
    {
        _musicService = musicService;
        _artistService = artistService;
    }
    public IActionResult Index()
    {
        var musics = _musicService.GetAll();
        return View(musics);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Save(RequestMusicDTO dto)
    {
        if(!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }
        this._musicService.Create(dto);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
