using App.BLL.Contracts;
using App.DTO.v1;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class RandomMiniaturePickerController : ControllerBase
{
    private readonly IAppBLL _bll;

    public RandomMiniaturePickerController(IAppBLL bll)
    {
        _bll = bll;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<RandomMiniaturePick>> GetRandomMiniature(Guid userId)
    {
        var result = await _bll.RandomMiniaturePickerService.GetRandomMiniatureToPaint(userId);
        if (result == null) return NotFound();
        return Ok(result);
    }
}