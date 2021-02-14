using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackLibraryWH40K.Application.Commands.Worlds;
using BlackLibraryWH40K.Application.Queries.Worlds;
using BlackLibraryWH40K.Store.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackLibraryWH40K.Controllers
{
    /// <summary>
    /// Контроллер для работы с мирами
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WorldsController : ControllerBase
    {
        private readonly IWorldsQueries _worldsQueries;
        private readonly IMediator _mediator;

        public WorldsController(IWorldsQueries worldsQueries, IMediator mediator)
        {
            _worldsQueries = worldsQueries;
            _mediator = mediator;
        }

        /// <summary>
        /// Возвращает список всех миров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var worlds = await _worldsQueries.GetAll();
            return Ok(worlds);
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var world = await _worldsQueries.GetById(id);
            return Ok(world);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]World world)
        {
            var worldId = await _mediator.Send(CreateWorld.Of(world));
            return Ok(worldId);
        }
    }
}
