using Banco.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banco.Application.Interfaces
{

    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetClientes();
        Task<ClienteDTO> GetById(int? id);
        Task Add(ClienteDTOPost clienteDto);
        Task Update(ClienteDTO clienteDto);
        Task Remove(int? id);
    }

}
