using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Http;

public class PlaylistController : ControllerBase
{
    // private readonly PlaylistService _playlistService;

    // public PlaylistController(PlaylistService playlistService)
    // {
    //     _playlistService = playlistService;
    // }

    // [HttpGet]
    // public IActionResult Get()
    // {
    //     return Ok(_playlistService.Get());
    // }

    // [HttpGet("{id}")]
    // public IActionResult GetById([FromRoute] string id)
    // {
    //     return Ok(_playlistService.GetById(id));
    // }

    // [HttpPost]
    // public IActionResult Create([FromBody] CreatePlaylistRequest request)
    // {
    //     _playlistService.Create(request);
    //     return Ok();
    // }
}
