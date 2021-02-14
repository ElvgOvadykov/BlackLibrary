using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackLibraryWH40K.Application.Commands.Chapters;
using BlackLibraryWH40K.Application.Queries.Chapters;
using BlackLibraryWH40K.Store.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlackLibraryWH40K.Controllers
{
    /// <summary>
    /// Контроллер для работы с орденами
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ChapterController : ControllerBase
    {
        private readonly ChaptersQueries _queries;
        private readonly IMediator _mediator;

        public ChapterController(IMediator mediator, ChaptersQueries queries)
        {
            _mediator = mediator;
            _queries = queries;
        }

        /// <summary>
        /// Возвращает список всех орденов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chapters = await _queries.GetAll();
            return Ok(chapters);
        }

        /// <summary>
        /// Возвращает орден по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id:int")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var chapter = await _queries.GetById(id);
            return Ok(chapter);
        }

        /// <summary>
        /// Добавляет новый орден
        /// </summary>
        /// <param name="chapter"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Chapter chapter)
        {
            var chapterId =  await _mediator.Send(CreateChapter.Of(chapter));
            return Ok(chapterId);
        }
    }
}
