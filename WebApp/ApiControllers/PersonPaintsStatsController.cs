using App.BLL.Contracts;
using App.DTO.v1;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class PersonPaintsStatsController : ControllerBase
{
    private readonly IAppBLL _bll;

    public PersonPaintsStatsController(IAppBLL bll)
    {
        _bll = bll;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<PersonPaintsStats>> GetUserStats(Guid userId)
    {
        var stats = await _bll.PersonPaintsStatsService.GetUserPaintsStats(userId);
        return Ok(stats);
    }
}