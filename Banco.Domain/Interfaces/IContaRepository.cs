using Banco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task<IEnumerable<Conta>> GetProdutosAsync();
        Task<Conta> GetByIdAsync(int? id);
        Task<Conta> CreateAsync(Conta product);
        Task<Conta> UpdateAsync(Conta product);
        Task<Conta> RemoveAsync(Conta product);
    }
}
