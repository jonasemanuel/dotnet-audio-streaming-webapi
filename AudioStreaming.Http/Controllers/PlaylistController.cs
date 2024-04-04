using AudioStreaming.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Http;

[ApiController]
[Route("playlists"), Authorize]
public class PlaylistController : ControllerBase
{
    private readonly PlaylistService _playlistService;

    public PlaylistController(PlaylistService playlistService)
    {
        _playlistService = playlistService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_playlistService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] string id)
    {
        return Ok(_playlistService.GetById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] RequestPlaylistDTO request)
    {
        _playlistService.Create(request);
        return Ok();
    }

    [HttpPost]
    [Route("{id}/musics/{musicId}")]
    public IActionResult AddMusic([FromRoute] string id, [FromRoute] string musicId)
    {
        _playlistService.AddMusic(id, musicId);
        return Ok();
    }
}
