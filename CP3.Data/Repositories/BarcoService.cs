using CP3.Domain.Interfaces.Dtos;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CP3.Application.Services
{
    public class BarcoService
    {
        private readonly IBarcoRepository _barcoRepository;

        public BarcoService(IBarcoRepository barcoRepository)
        {
            _barcoRepository = barcoRepository;
        }

        public BarcoDto ObterPorId(int id)
        {
            var barco = _barcoRepository.ObterPorId(id);
            return barco != null ? MapToDto(barco) : null;
        }

        public IEnumerable<BarcoDto> ObterTodos()
        {
            var barcos = _barcoRepository.ObterTodos();
            return barcos.Select(MapToDto);
        }

        public BarcoDto Adicionar(BarcoDto barcoDto)
        {
            barcoDto.Validate();

            var barcoEntity = MapToEntity(barcoDto);
            var barcoAdicionado = _barcoRepository.Adicionar(barcoEntity);
            return MapToDto(barcoAdicionado);
        }

        public BarcoDto Editar(BarcoDto barcoDto)
        {
            barcoDto.Validate();

            var barcoEntity = MapToEntity(barcoDto);
            var barcoEditado = _barcoRepository.Editar(barcoEntity);
            return barcoEditado != null ? MapToDto(barcoEditado) : null;
        }

        public bool Remover(int id)
        {
            return _barcoRepository.Remover(id);
        }

        private BarcoDto MapToDto(BarcoEntity barco)
        {
            return new BarcoDto
            {
                Id = barco.Id,
                Nome = barco.Nome,
                Modelo = barco.Modelo,
                Ano = barco.Ano,
                Tamanho = barco.Tamanho
            };
        }

        private BarcoEntity MapToEntity(BarcoDto barcoDto)
        {
            return new BarcoEntity
            {
                Id = barcoDto.Id,
                Nome = barcoDto.Nome,
                Modelo = barcoDto.Modelo,
                Ano = barcoDto.Ano,
                Tamanho = barcoDto.Tamanho
            };
        }
    }
}
