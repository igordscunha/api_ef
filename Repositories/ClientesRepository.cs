using API_EF.Data;
using API_EF.Data.Dtos;
using API_EF.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API_EF.Repositories;

public interface IClientesRepository
{
    public bool Create(CreateClienteDto cliente);
    public IEnumerable<ReadClienteDto> Read();
    public ReadClienteDto ReadPerId(int id);
    public bool Update(UpdateClienteDto cliente, int id);
    public bool UpdatePatch(JsonPatchDocument<UpdateClienteDto> cliente, int id);
    public bool Delete(int id);
}
public class ClientesRepository : IClientesRepository
{
    private IMapper _mapper;
    private _DbContext _context;

    public ClientesRepository(IMapper mapper, _DbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public bool Create(CreateClienteDto clienteDto)
    {
        try
        {
            Clientes novoCliente = _mapper.Map<Clientes>(clienteDto);
            _context.Clientes.Add(novoCliente);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<ReadClienteDto> Read()
    {
        try
        {
            return _mapper.Map<List<ReadClienteDto>>(_context.Clientes.ToList());
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            return Enumerable.Empty<ReadClienteDto>();
        }
    }

    public ReadClienteDto ReadPerId(int id)
    {
        try 
        {
            var clienteDb = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (clienteDb == null)
                throw new ApplicationException("Este usuário não existe.");

            var clienteDto = _mapper.Map<ReadClienteDto>(clienteDb);
            return clienteDto;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            throw new ApplicationException("Não foi possível recuperar este cliente.");
        }
    }

    public bool Update(UpdateClienteDto clienteDto, int id)
    {
        try 
        {
            var clienteDb = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (clienteDb == null)
                return false;

            _mapper.Map(clienteDto, clienteDb);
            _context.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdatePatch(JsonPatchDocument<UpdateClienteDto> cliente, int id)
    {
        try
        {
            var clienteDb = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (clienteDb == null)
                return false;

            var clienteParaAtualizar = _mapper.Map<UpdateClienteDto>(clienteDb);

            cliente.ApplyTo(clienteParaAtualizar);

            _mapper.Map(clienteParaAtualizar, clienteDb);
            _context.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var usuarioDb = _context.Clientes.FirstOrDefault(x => x.Id == id);
            _context.Clientes.Remove(usuarioDb);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
