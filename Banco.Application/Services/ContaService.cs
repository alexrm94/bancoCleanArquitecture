using AutoMapper;
using Banco.Application.DTOs;
using Banco.Application.Interfaces;
using Banco.Domain.Entities;
using Banco.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banco.Application.Services
{
    public class ContaService: IContaService
    {
        private IContaRepository _contaRepository;

        private readonly IMapper _mapper;
        public ContaService(IMapper mapper, IContaRepository contaRepository)
        {
            _contaRepository = contaRepository ??
                 throw new ArgumentNullException(nameof(contaRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ContaDTO>> GetContas()
        {
            var contaEntity = await _contaRepository.GetProdutosAsync();
            return _mapper.Map<IEnumerable<ContaDTO>>(contaEntity);
        }

        public async Task<ContaDTO> GetById(int? id)
        {
            var contaEntity = await _contaRepository.GetByIdAsync(id);
            return _mapper.Map<ContaDTO>(contaEntity);
        }

        public async Task Add(ContaDTOPost contaDto)
        {
            var contaEntity = _mapper.Map<Conta>(contaDto);
            await _contaRepository.CreateAsync(contaEntity);
        }

        public async Task Update(ContaDTO contaDto)
        {

            var contaEntity = _mapper.Map<Conta>(contaDto);
            await _contaRepository.UpdateAsync(contaEntity);
        }

        public async Task Remove(int? id)
        {
            var contaEntity = _contaRepository.GetByIdAsync(id).Result;
            await _contaRepository.RemoveAsync(contaEntity);
        }
    }
}
