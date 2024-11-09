using CP3.Domain.Entities;
using CP3.Infrastructure;
using CP3.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace CP3.Tests.Infrastructure
{
    public class BarcoRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly BarcoRepository _barcoRepository;

        public BarcoRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationContext(_options);
            _barcoRepository = new BarcoRepository(_context);
        }

        [Fact]
        public void ObterPorId_DeveRetornarBarcoEntity_QuandoIdExistir()
        {
            // Arrange
            var barco = new BarcoEntity { Nome = "Barco Teste", Modelo = "Modelo Teste", Ano = 2020, Tamanho = 15.5 };
            _context.Barcos.Add(barco);
            _context.SaveChanges();

            // Act
            var result = _barcoRepository.ObterPorId(barco.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Barco Teste", result.Nome);
        }

        [Fact]
        public void Adicionar_DeveSalvarBarcoNoBanco()
        {
            // Arrange
            var barco = new BarcoEntity { Nome = "Barco Novo", Modelo = "Modelo Novo", Ano = 2021, Tamanho = 20.0 };

            // Act
            _barcoRepository.Adicionar(barco);
            var result = _context.Barcos.FirstOrDefault(b => b.Nome == "Barco Novo");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Barco Novo", result.Nome);
        }

        [Fact]
        public void Editar_DeveAtualizarDadosDoBarco()
        {
            // Arrange
            var barco = new BarcoEntity { Nome = "Barco Original", Modelo = "Modelo Original", Ano = 2019, Tamanho = 18.0 };
            _context.Barcos.Add(barco);
            _context.SaveChanges();

            barco.Nome = "Barco Editado";

            // Act
            _barcoRepository.Editar(barco);
            var result = _context.Barcos.FirstOrDefault(b => b.Id == barco.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Barco Editado", result.Nome);
        }

        [Fact]
        public void Remover_DeveExcluirBarcoDoBanco()
        {
            // Arrange
            var barco = new BarcoEntity { Nome = "Barco Remover", Modelo = "Modelo Remover", Ano = 2018, Tamanho = 16.0 };
            _context.Barcos.Add(barco);
            _context.SaveChanges();

            // Act
            var sucesso = _barcoRepository.Remover(barco.Id);
            var result = _context.Barcos.FirstOrDefault(b => b.Id == barco.Id);

            // Assert
            Assert.True(sucesso);
            Assert.Null(result);
        }
    }
}
