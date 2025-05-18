using App.BLL.Contracts;
using App.DTO.v1;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MiniatureCollectionStatsController : ControllerBase
{
    private readonly IMiniatureCollectionStatsService _statsService;

    public MiniatureCollectionStatsController(IMiniatureCollectionStatsService statsService)
    {
        _statsService = statsService;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<MiniatureCollectionStats>> GetUserStats(Guid userId)
    {
        var stats = await _statsService.GetUserCollectionStats(userId);
        return Ok(stats);
    }
}