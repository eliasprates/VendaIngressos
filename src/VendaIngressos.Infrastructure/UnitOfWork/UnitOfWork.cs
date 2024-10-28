using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaIngressos.Application.Interfaces;
using VendaIngressos.Domain.Interfaces;
using VendaIngressos.Infrastructure.Data;
using VendaIngressos.Infrastructure.Repositories;

namespace VendaIngressos.Infrastructure.UnitOfWork
{
    public class MyUnitOfWork : IUnitOfWork
    {
        private readonly VendaIngressosContext _context;

        public MyUnitOfWork(VendaIngressosContext context)
        {
            _context = context;
            Produtos = new ProdutoRepository(_context);
            ProdutoDescontos = new ProdutoDescontoRepository(_context);
        }

        public IProdutoRepository Produtos { get; private set; }
        public IProdutoDescontoRepository ProdutoDescontos { get; private set; }

        public async Task<int> CompletarAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }


}
