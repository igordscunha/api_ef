using API_EF.Data.Dtos;
using API_EF.Models;
using API_EF.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_EF.Controllers;

[Route("api/Clientes")]
public class ClientesController : Controller
{

    private readonly IClientesRepository _repository;

    public ClientesController(IClientesRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var clienteDb = _repository.Read();
            return Ok(clienteDb);
    }

    [HttpGet("{id}")]
    public IActionResult GetId([FromRoute] int id)
    {
        var clienteDb = _repository.ReadPerId(id);
            return Ok(clienteDb);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateClienteDto clienteDto)
    {
        if(_repository.Create(clienteDto))
            return Ok(clienteDto);

        return BadRequest("Não foi possível criar o cliente.");
    }

    [HttpPut("{id}")]
    public IActionResult Put([FromBody] UpdateClienteDto clienteDto, [FromRoute] int id)
    {
        if(_repository.Update(clienteDto, id))
            return Ok(clienteDto);

        return NotFound("Não foi possível localizar o cliente.");
    }

    [HttpPatch("{id}")]
    public IActionResult Patch([FromBody] JsonPatchDocument<UpdateClienteDto> cliente, [FromRoute] int id)
    {
        if(_repository.UpdatePatch(cliente, id))
            return Ok(cliente);

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        if (_repository.Delete(id))
            return Ok("Cliente excluído com sucesso!");

        return BadRequest("Não foi possível deletar o cliente.");
    }
}
