using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackLibraryWH40K.Application.Commands.State;
using BlackLibraryWH40K.Application.Queries.State;
using BlackLibraryWH40K.Store.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackLibraryWH40K.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateQueries _queries;
        private readonly IMediator _mediator;

        public StateController(IStateQueries queries, IMediator mediator)
        {
            _queries = queries;
            _mediator = mediator;
        }

        /// <summary>
        /// Возвращает список сторон
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var states = await _queries.GetAllAsync();
            return Ok(states);
        }

        /// <summary>
        /// Возвращает сторону по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор стороны</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById([FromRoute]int id)
        {
            var state = await _queries.GetByIdAsync(id);
            return Ok(state);
        }

        /// <summary>
        /// Создает новую сторону
        /// </summary>
        /// <param name="state">Сторона</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] State state)
        {
            var stateId = await _mediator.Send(CreateState.Of(state));
            return Ok(stateId);
        }

        /// <summary>
        /// Обновляет информацию о стороне
        /// </summary>
        /// <param name="state">Сторона</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] State state)
        {
            await _mediator.Send(UpdateState.Of(state));
            return Ok();
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
