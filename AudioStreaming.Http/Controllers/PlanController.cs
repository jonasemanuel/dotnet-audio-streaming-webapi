using AudioStreaming.Application;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Http;

[ApiController]
[Route("plans")]
public class PlanController : ControllerBase
{
    private readonly PlanService _planService;

    public PlanController(PlanService planService)
    {
        _planService = planService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_planService.GetAll());
    }

    [HttpPost]
    public IActionResult Create([FromBody] RequestPlanDTO request)
    {
        if(ModelState.IsValid == false) return BadRequest(ModelState);
        
        _planService.Create(request);
        return Ok();
    }
}
