using App.BLL.Contracts;
using App.DTO.v1;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MiniatureCollectionStatsController : ControllerBase
{
    private readonly IAppBLL _bll;

    public MiniatureCollectionStatsController(IAppBLL bll)
    {
        _bll = bll;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<MiniatureCollectionStats>> GetUserStats(Guid userId)
    {
        var stats = await _bll.MiniatureCollectionStatsService.GetUserCollectionStats(userId);
        return Ok(stats);
    }
}