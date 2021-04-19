using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Lancamento;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private ILancamentoService _service;

        public LancamentosController(ILancamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}", Name = "GetLancamentoWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // 400 bad request
                }
                var result = await _service.Get(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LancamentoDtoCreate lancamento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // 400 bad request
                }

                var result = await _service.Post(lancamento);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetLancamentoWithId", new { id = result.Id })), result);
                }

                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
