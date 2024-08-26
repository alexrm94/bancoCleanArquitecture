using Banco.Domain.Entities;
using Banco.Domain.Interfaces;
using Banco.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banco.Infrastructure.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private AppDbContext _contaContext;
        public ContaRepository(AppDbContext context)
        {
            _contaContext = context;
        }

        public async Task<Conta> CreateAsync(Conta product)
        {
            _contaContext.Add(product);
            await _contaContext.SaveChangesAsync();
            return product;
        }

        public async Task<Conta> GetByIdAsync(int? id)
        {
            //return await _productContext.Produtos.FindAsync(id);
            return await _contaContext.Contas.Include(c => c.Cliente)
               .SingleOrDefaultAsync(p => p.ContaId == id);
        }

        public async Task<IEnumerable<Conta>> GetProdutosAsync()
        {
            return await _contaContext.Contas.ToListAsync();
        }

        public async Task<Conta> RemoveAsync(Conta product)
        {
            _contaContext.Remove(product);
            await _contaContext.SaveChangesAsync();
            return product;
        }

        public async Task<Conta> UpdateAsync(Conta product)
        {
            _contaContext.Update(product);
            await _contaContext.SaveChangesAsync();
            return product;
        }
    }
}
