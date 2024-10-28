using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaIngressos.Domain.Entities;
using VendaIngressos.Domain.Interfaces;
using VendaIngressos.Infrastructure.Data;

namespace VendaIngressos.Infrastructure.Repositories
{
    public class ProdutoDescontoRepository : IProdutoDescontoRepository
    {
        private readonly VendaIngressosContext _context;

        public ProdutoDescontoRepository(VendaIngressosContext context)
        {
            _context = context;
        }
        public async Task<ProdutoDesconto> ObterPorCodigo(int codigo)
        {
            return await _context.ProdutoDescontos
                .FirstOrDefaultAsync(pd => pd.Codigo == codigo);
        }

        public async Task<List<ProdutoDesconto>> ObterDescontosPorCodigoProduto(int codigoProduto)
        {
            return await _context.ProdutoDescontos
                .Where(pd => pd.ProdutoCodigo == codigoProduto)
                .ToListAsync();
        }

        public async Task<List<ProdutoDesconto>> ObterTodos()
        {
            return await _context.ProdutoDescontos.ToListAsync();
        }

        public async Task Adicionar(ProdutoDesconto produtoDesconto)
        {
            await _context.ProdutoDescontos.AddAsync(produtoDesconto);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(ProdutoDesconto produtoDesconto)
        {
            _context.ProdutoDescontos.Update(produtoDesconto);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int codigo)
        {
            var produtoDesconto = await ObterPorCodigo(codigo);
            if (produtoDesconto != null)
            {
                _context.ProdutoDescontos.Remove(produtoDesconto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
