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
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientes()
        {
            try
            {
                var categoriesEntity = await _clienteRepository.GetClientesAsync();
                var categoriasDto = _mapper.Map<IEnumerable<ClienteDTO>>(categoriesEntity);
                return categoriasDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClienteDTO> GetById(int? id)
        {
            var categoryEntity = await _clienteRepository.GetByIdAsync(id);
            return _mapper.Map<ClienteDTO>(categoryEntity);
        }

        public async Task Add(ClienteDTOPost categoryDto)
        {
            var categoryEntity = _mapper.Map<Cliente>(categoryDto);
            await _clienteRepository.CreateAsync(categoryEntity);
        }

        public async Task Update(ClienteDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Cliente>(categoryDto);
            await _clienteRepository.UpdateAsync(categoryEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _clienteRepository.GetByIdAsync(id).Result;
            await _clienteRepository.RemoveAsync(categoryEntity);
        }
    }
}