using Banco.Application.DTOs;


namespace Banco.Application.Interfaces
{
    public interface IContaService
    {
        Task<IEnumerable<ContaDTO>> GetContas();
        Task<ContaDTO> GetById(int? id);
        Task Add(ContaDTOPost contaDto);
        Task Update(ContaDTO contaDto);
        Task Remove(int? id);
    }
}
