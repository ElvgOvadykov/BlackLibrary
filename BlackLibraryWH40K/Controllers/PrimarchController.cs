using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackLibraryWH40K.Application.Commands.Primarch;
using BlackLibraryWH40K.Application.Queries.Primarch;
using BlackLibraryWH40K.Store.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackLibraryWH40K.Controllers
{
    /// <summary>
    /// api controller для работы с примархами
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PrimarchController : ControllerBase
    {
        private readonly IPrimarchQueries _queries;
        private readonly IMediator _mediator;

        public PrimarchController(IPrimarchQueries queries, IMediator mediator)
        {
            _queries = queries;
            _mediator = mediator;
        }

        /// <summary>
        /// Возвращает всех примархов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var primarchs = await _queries.GetAllAsync();
            return Ok(primarchs);
        }

        /// <summary>
        /// Возвращает примарха по номеру
        /// </summary>
        /// <param name="number">Номер примарха</param>
        /// <returns></returns>
        [HttpGet("{number:int}")]
        public async Task<ActionResult> Get([FromRoute]int number)
        {
            var primarch = await _queries.GetByNumberAsync(number);
            return Ok(primarch);
        }

        /// <summary>
        /// Добавляет примарха
        /// </summary>
        /// <param name="primarch">Примарх</param>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Primarch primarch)
        {
            var primarchNumber = await _mediator.Send(CreatePrimarch.Of(primarch));
            return Ok(primarchNumber);
        }

        /// <summary>
        /// Обновление информации о примархе
        /// </summary>
        /// <param name="primarch">Примарх</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Primarch primarch)
        {
            await _mediator.Send(UpdatePrimarch.Of(primarch));
            return Ok();
        }
    }
}
