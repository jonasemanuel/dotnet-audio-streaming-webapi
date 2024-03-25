using AudioStreaming.Application;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Http;

[ApiController]
[Route("artists")]
public class ArtistController : ControllerBase
{
    private readonly ArtistService _artistService;

    public ArtistController(ArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] RequestArtistDTO request)
    {
        if(ModelState.IsValid == false) return BadRequest(ModelState);

        _artistService.Create(request);
        return Ok();
    }

    [HttpPost]
    [Route("{id}/albums")]
    public IActionResult Create(Guid id, [FromBody] RequestAlbumDTO request)
    {
        if(ModelState.IsValid == false) return BadRequest(ModelState);

        _artistService.AddAlbum(id, request);
        return Ok();
    }
}
