using Microsoft.AspNetCore.Mvc;
using Banco.Application.DTOs;
using Banco.Application.Interfaces;
using Banco.Domain.Entities;


namespace Banco.API.Controllers
{
    public class ContasController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContasController(IContaService contaService)
        {
            _contaService = contaService;
        }

        // api/contas
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ContaDTO>>> Get()
        {
            var contas = await _contaService.GetContas();
            return Ok(contas);
        }

        [HttpGet("{id}", Name = "GetConta")]
        public async Task<ActionResult<ContaDTO>> Get(int id)
        {
            var conta = await _contaService.GetById(id);

            if (conta == null)
            {
                return NotFound();
            }
            return Ok(conta);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Post([FromBody] ContaDTOPost contaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contaService.Add(contaDto);

            return Ok(contaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ContaDTO contaDto)
        {
            if (id != contaDto.ContaId)
            {
                return BadRequest();
            }

            await _contaService.Update(contaDto);

            return Ok(contaDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContaDTO>> Delete(int id)
        {
            var contaDto = await _contaService.GetById(id);
            if (contaDto == null)
            {
                return NotFound();
            }
            await _contaService.Remove(id);
            return Ok(contaDto);
        }
    }
}
