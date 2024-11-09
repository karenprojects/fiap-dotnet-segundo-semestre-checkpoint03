using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using Fluent.Infrastructure.FluentModel;
using System.Collections.Generic;
using System.Linq;

namespace CP3.Infrastructure.Repositories
{
    public class BarcoRepository : IBarcoRepository
    {
        private readonly ApplicationContext _context;

        public BarcoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public BarcoEntity? ObterPorId(int id)
        {
            return _context.Barcos.Find(id);
        }

        public IEnumerable<BarcoEntity> ObterTodos()
        {
            return _context.Barcos.ToList();
        }

        public BarcoEntity Adicionar(BarcoEntity barco)
        {
            _context.Barcos.Add(barco);
            _context.SaveChanges();
            return barco;
        }

        public BarcoEntity Editar(BarcoEntity barco)
        {
            var entity = _context.Barcos.Find(barco.Id);
            if (entity == null) return null;

            entity.Nome = barco.Nome;
            entity.Modelo = barco.Modelo;
            entity.Ano = barco.Ano;
            entity.Tamanho = barco.Tamanho;

            _context.SaveChanges();
            return entity;
        }

        public bool Remover(int id)
        {
            var entity = _context.Barcos.Find(id);
            if (entity == null) return false;

            _context.Barcos.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
