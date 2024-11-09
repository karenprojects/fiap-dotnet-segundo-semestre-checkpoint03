using CP3.Application.Dtos;
using CP3.Application.Services;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CP3.Tests.Application
{
    public class BarcoServiceTests
    {
        private readonly Mock<IBarcoRepository> _barcoRepositoryMock;
        private readonly BarcoService _barcoService;

        public BarcoServiceTests()
        {
            _barcoRepositoryMock = new Mock<IBarcoRepository>();
            _barcoService = new BarcoService(_barcoRepositoryMock.Object);
        }

        [Fact]
        public void ObterPorId_DeveRetornarBarcoDto_QuandoIdExistir()
        {
            // Arrange
            var barco = new BarcoEntity { Id = 1, Nome = "Barco 1", Modelo = "Modelo 1", Ano = 2020, Tamanho = 15.5 };
            _barcoRepositoryMock.Setup(repo => repo.ObterPorId(1)).Returns(barco);

            // Act
            var result = _barcoService.ObterPorId(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Barco 1", result.Nome);
            _barcoRepositoryMock.Verify(repo => repo.ObterPorId(1), Times.Once);  // Verifica se o método foi chamado
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeBarcoDto()
        {
            // Arrange
            var barcos = new List<BarcoEntity>
            {
                new BarcoEntity { Id = 1, Nome = "Barco 1", Modelo = "Modelo 1", Ano = 2020, Tamanho = 15.5 },
                new BarcoEntity { Id = 2, Nome = "Barco 2", Modelo = "Modelo 2", Ano = 2021, Tamanho = 20.0 }
            };
            _barcoRepositoryMock.Setup(repo => repo.ObterTodos()).Returns(barcos);

            // Act
            var result = _barcoService.ObterTodos();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
            _barcoRepositoryMock.Verify(repo => repo.ObterTodos(), Times.Once);  // Verifica se o método foi chamado
        }

        [Fact]
        public void Adicionar_DeveRetornarBarcoDto_QuandoAdicionarComSucesso()
        {
            // Arrange
            var barcoDto = new BarcoDto { Nome = "Barco 1", Modelo = "Modelo 1", Ano = 2020, Tamanho = 15.5 };
            var barcoEntity = new BarcoEntity { Id = 1, Nome = "Barco 1", Modelo = "Modelo 1", Ano = 2020, Tamanho = 15.5 };
            _barcoRepositoryMock.Setup(repo => repo.Adicionar(It.IsAny<BarcoEntity>())).Returns(barcoEntity);

            // Act
            var result = _barcoService.Adicionar(barcoDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Barco 1", result.Nome);
            _barcoRepositoryMock.Verify(repo => repo.Adicionar(It.IsAny<BarcoEntity>()), Times.Once);  // Verifica se o método foi chamado
        }

        [Fact]
        public void Editar_DeveRetornarBarcoDto_QuandoEditarComSucesso()
        {
            // Arrange
            var barcoDto = new BarcoDto { Id = 1, Nome = "Barco 1 Atualizado", Modelo = "Modelo Atualizado", Ano = 2021, Tamanho = 16.0 };
            var barcoEntity = new BarcoEntity { Id = 1, Nome = "Barco 1 Atualizado", Modelo = "Modelo Atualizado", Ano = 2021, Tamanho = 16.0 };
            _barcoRepositoryMock.Setup(repo => repo.Editar(It.IsAny<BarcoEntity>())).Returns(barcoEntity);

            // Act
            var result = _barcoService.Editar(barcoDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Barco 1 Atualizado", result.Nome);
            _barcoRepositoryMock.Verify(repo => repo.Editar(It.IsAny<BarcoEntity>()), Times.Once);  // Verifica se o método foi chamado
        }

        [Fact]
        public void Remover_DeveRetornarTrue_QuandoRemovidoComSucesso()
        {
            // Arrange
            _barcoRepositoryMock.Setup(repo => repo.Remover(1)).Returns(true);

            // Act
            var result = _barcoService.Remover(1);

            // Assert
            Assert.True(result);
            _barcoRepositoryMock.Verify(repo => repo.Remover(1), Times.Once);  // Verifica se o método foi chamado
        }
    }
}
