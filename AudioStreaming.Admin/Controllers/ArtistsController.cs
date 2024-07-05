using AudioStreaming.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Admin;

[Authorize]
public class ArtistsController : Controller
{
    private readonly ArtistService _artistService;
    public ArtistsController(ArtistService artistService)
    {
        _artistService = artistService;
    }
    public IActionResult Index()
    {
        var artists = _artistService.GetAll();
        return View(artists);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Save(RequestArtistDTO dto)
    {
        if(!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }
        this._artistService.Create(dto);
        return RedirectToAction("Index");
    }
}
