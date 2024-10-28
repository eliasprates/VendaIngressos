using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendaIngressos.Domain.Entities;
using VendaIngressos.Domain.Interfaces;
using VendaIngressos.Infrastructure.Data;

namespace VendaIngressos.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly VendaIngressosContext _context;

        public ProdutoRepository(VendaIngressosContext context)
        {
            _context = context;
        }

        public async Task<Produto> ObterPorCodigoAsync(int codigo)
        {
            return await _context.Produtos.SingleOrDefaultAsync(p => p.Codigo == codigo);
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

       public async Task RemoverAsync(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }
    }
}
