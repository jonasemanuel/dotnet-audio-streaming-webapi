using AudioStreaming.Application;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Http;

[ApiController]
[Route("musics")]
public class MusicController : ControllerBase
{
    private readonly MusicService _musicService;

    public MusicController(MusicService musicService)
    {
        _musicService = musicService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_musicService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] string id)
    {
        return Ok(_musicService.GetById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] RequestMusicDTO request)
    {
        if(ModelState.IsValid == false) return BadRequest(ModelState);
        
        _musicService.Create(request);
        return Ok();
    }

    [HttpGet]
    [Route("search")]
    public IActionResult Search([FromQuery] string q)
    {
        return Ok(_musicService.Search(q));
    }
}
