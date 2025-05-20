using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.BLL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;
using Asp.Versioning;
using Base.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Controller for handling CRUD operations related to MiniPaintSwatch.
    /// </summary>
    /// <remarks>
    /// Provides endpoints to retrieve all MiniPaintSwatches, get a specific MiniPaintSwatch by ID,
    /// create a new MiniPaintSwatch, update an existing MiniPaintSwatch, and delete a MiniPaintSwatch.
    /// Methods in this controller handle user-specific data, enforce authorization,
    /// and return appropriate HTTP status codes based on outcomes.
    /// </remarks>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MiniPaintSwatchController : ControllerBase
    {
        private readonly ILogger<MiniPaintSwatchController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.MiniPaintSwatchMapper _mapper =
            new App.DTO.v1.Mappers.MiniPaintSwatchMapper();

        public MiniPaintSwatchController(IAppBLL bll, ILogger<MiniPaintSwatchController> logger)
        {
            _bll = bll;
            _logger = logger;
        }

        /// <summary>
        ///  Get all MiniPaintSwatches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.MiniPaintSwatch> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.MiniPaintSwatch>>> GetMiniPaintSwatches()
        {
            var data = await _bll.MiniPaintSwatchService.AllAsync(User.GetUserId());
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        /// <summary>
        ///  Get MiniPaintSwatch by Id - owned by current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(App.DTO.v1.MiniPaintSwatch), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.MiniPaintSwatch>> GetMiniPaintSwatch(Guid id)
        {
            var miniPaintSwatch = await _bll.MiniPaintSwatchService.FindAsync(id, User.GetUserId());

            if (miniPaintSwatch == null)
            {
                return NotFound();
            }

            return _mapper.Map(miniPaintSwatch)!;
        }

        /// <summary>
        /// Update MiniPaintSwatch by Id - owned by current user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="miniPaintSwatch"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniPaintSwatch(Guid id, App.DTO.v1.MiniPaintSwatch miniPaintSwatch)
        {
            if (id != miniPaintSwatch.Id)
            {
                return BadRequest();
            }

            await _bll.MiniPaintSwatchService.UpdateAsync(_mapper.Map(miniPaintSwatch)!, User.GetUserId());
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        ///  Create new MiniPaintSwatch - owned by current user
        /// </summary>
        /// <param name="miniPaintSwatch"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(App.DTO.v1.PersonPaints), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.MiniPaintSwatch>> PostMiniPaintSwatch(App.DTO.v1.MiniPaintSwatch miniPaintSwatch)
        {
            var bllMiniPaintSwatches = _mapper.Map(miniPaintSwatch);
            _bll.MiniPaintSwatchService.Add(bllMiniPaintSwatches, User.GetUserId());
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetMiniPaintSwatch", new { id = bllMiniPaintSwatches.Id }, miniPaintSwatch);
        }

        /// <summary>
        /// Delete PersonPaints by id - owned by current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniPaintSwatch(Guid id)
        {
            await _bll.MiniPaintSwatchService.RemoveAsync(id, User.GetUserId());
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
