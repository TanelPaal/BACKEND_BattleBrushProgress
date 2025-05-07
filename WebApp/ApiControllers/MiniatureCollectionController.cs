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
    ///  Controller for MiniatureCollection
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MiniatureCollectionController : ControllerBase
    {
        private readonly ILogger<MiniatureCollectionController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.MiniatureCollectionMapper _mapper =
            new App.DTO.v1.Mappers.MiniatureCollectionMapper();

        /// <summary>
        ///  Constructor for MiniatureCollectionController
        /// </summary>
        /// <param name="bll"></param>
        /// <param name="logger"></param>
        public MiniatureCollectionController(IAppBLL bll, ILogger<MiniatureCollectionController> logger)
        {
            _bll = bll;
            _logger = logger;
        }

        /// <summary>
        ///  Get all MiniatureCollections for current user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.MiniatureCollection> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.MiniatureCollection>>> GetMiniatureCollections()
        {
            var data = await _bll.MiniatureCollectionService.AllAsync(User.GetUserId());
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        /// <summary>
        ///  Get MiniatureCollection by Id - owned by current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(App.DTO.v1.MiniatureCollection), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.MiniatureCollection>> GetMiniatureCollection(Guid id)
        {
            var miniatureCollection = await _bll.MiniatureCollectionService.FindAsync(id, User.GetUserId());

            if (miniatureCollection == null)
            {
                return NotFound();
            }

            return _mapper.Map(miniatureCollection)!;
        }

        /// <summary>
        ///  Update MiniatureCollection - owned by current user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="miniatureCollection"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniatureCollection(Guid id, App.DTO.v1.MiniatureCollection miniatureCollection)
        {
            if (id != miniatureCollection.Id)
            {
                return BadRequest();
            }

            await _bll.MiniatureCollectionService.UpdateAsync(_mapper.Map(miniatureCollection)!, User.GetUserId());
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        ///  Create new MiniatureCollection - owned by current user
        /// </summary>
        /// <param name="miniatureCollection"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(App.DTO.v1.MiniatureCollection), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.MiniatureCollection>> PostMiniatureCollection(App.DTO.v1.MiniatureCollection miniatureCollection)
        {
            var bllMiniatureCollection = _mapper.Map(miniatureCollection);
            _bll.MiniatureCollectionService.Add(bllMiniatureCollection, User.GetUserId());
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetMiniatureCollection", new { id = bllMiniatureCollection.Id }, miniatureCollection);
        }

        /// <summary>
        ///  Delete MiniatureCollection by id - owned by current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniatureCollection(Guid id)
        {
            await _bll.MiniatureCollectionService.RemoveAsync(id, User.GetUserId());
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
