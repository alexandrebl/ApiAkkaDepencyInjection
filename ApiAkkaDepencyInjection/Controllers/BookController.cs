using ApiAkkaDepencyInjection.Domain;
using ApiAkkaDepencyInjection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ApiAkkaDepencyInjection.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IQueryServices _queryServices;
        private readonly ILogger<BookController> _logger;

        public BookController(IQueryServices queryServices, ILogger<BookController> logger)
        {
            _queryServices = queryServices;
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Query()
        {
            try
            {
                _logger.LogInformation("Request information");

                if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.ValidationState);

                var result = _queryServices.Query();

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{code}")]
        public IActionResult QueryByCode([FromRoute] string code)
        {
            try
            {
                _logger.LogInformation("Request information", code);

                if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.ValidationState);

                var result = _queryServices.QueryByCode(code);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, code);

                return new StatusCodeResult(500);
            }
        }

        [HttpGet("isbn/{isbn}")]
        public IActionResult QueryByIsbn([FromRoute] string isbn)
        {
            try
            {
                _logger.LogInformation("Request information", isbn);

                if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.ValidationState);

                var result = _queryServices.QueryByIsbn(isbn);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, isbn);

                return new StatusCodeResult(500);
            }
        }

        [HttpGet("publish/{startDataDateTime}/{endDateTime}")]
        public IActionResult QueryByDate([FromRoute] DateTime startDataDateTime, [FromRoute] DateTime endDateTime)
        {
            try
            {
                _logger.LogInformation("Request information", new { startDataDateTime, endDateTime });

                if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.ValidationState);

                var result = _queryServices.Query(startDataDateTime, endDateTime);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, new { startDataDateTime, endDateTime });

                return new StatusCodeResult(500);
            }
        }

        [HttpGet("author/{author}/{startDataDateTime}/{endDateTime}")]
        public IActionResult QueryByAuthor([FromRoute] string author,
            [FromRoute] DateTime startDataDateTime, [FromRoute] DateTime endDateTime)
        {
            try
            {
                _logger.LogInformation("Request information", new { startDataDateTime, endDateTime });

                if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.ValidationState);

                var result = _queryServices.QueryByAuthorAndDate(author, startDataDateTime, endDateTime);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, new { startDataDateTime, endDateTime });

                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult InsertBook([FromBody] Book book)
        {
            try
            {
                _logger.LogInformation("Request information", book);

                if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.ValidationState);

                _queryServices.Insert(book);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, book);

                return new StatusCodeResult(500);
            }
        }
    }
}