using Banco.Application.DTOs;
using Banco.Application.Interfaces;
using Banco.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Banco.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;
    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
    {
        try
        {
            var clientes = await _clienteService.GetClientes();
            return Ok(clientes);
        }
        catch
        {
            throw;
        }
    }

    [HttpGet("{id}", Name = "GetCliente")]
    public async Task<ActionResult<Cliente>> Get(int id)
    {
        var cliente = await _clienteService.GetById(id);

        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ClienteDTOPost clienteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _clienteService.Add(clienteDto);

        return Ok();
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO clienteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (id != clienteDto.ClienteId)
        {
            return BadRequest();
        }
        await _clienteService.Update(clienteDto);
        return Ok(clienteDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Cliente>> Delete(int id)
    {
        var clienteDto = await _clienteService.GetById(id);
        if (clienteDto == null)
        {
            return NotFound();
        }
        await _clienteService.Remove(id);
        return Ok(clienteDto);
    }
}