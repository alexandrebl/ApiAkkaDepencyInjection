using ApiAkkaDepencyInjection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiAkkaDepencyInjection.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        private readonly IQueryServices _queryServices;

        public DrawController(IQueryServices queryServices)
        {
            _queryServices = queryServices;
        }

        [HttpGet("{code}")]
        public IActionResult Query([FromRoute] string code)
        {
            try
            {
                var result = _queryServices.Query(code);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}