using Banco.Domain.Entities;
using Banco.Domain.Interfaces;
using Banco.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banco.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private AppDbContext _clienteContext;
    public ClienteRepository(AppDbContext context)
    {
        _clienteContext = context;
    }

    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        _clienteContext.Add(cliente);
        await _clienteContext.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> GetByIdAsync(int? id)
    {
        return await _clienteContext.Clientes.FindAsync(id);
    }

    public async Task<IEnumerable<Cliente>> GetClientesAsync()
    {
        try
        {
            var categorias = await _clienteContext.Clientes.ToListAsync();
            return categorias;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task<Cliente> RemoveAsync(Cliente category)
    {
        _clienteContext.Remove(category);
        await _clienteContext.SaveChangesAsync();
        return category;
    }

    public async Task<Cliente> UpdateAsync(Cliente category)
    {
        _clienteContext.Update(category);
        await _clienteContext.SaveChangesAsync();
        return category;
    }
}