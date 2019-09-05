using ApiAkkaDepencyInjection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using ApiAkkaDepencyInjection.Domain;
using Microsoft.Extensions.Logging;

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

                _queryServices.Insert(book);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, book);

                return new StatusCodeResult(500);
            }
        }

        /*
         void Insert(Book draw);        
         */
    }
}