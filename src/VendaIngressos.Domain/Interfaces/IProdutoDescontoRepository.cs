using System.Collections.Generic;
using System.Threading.Tasks;
using VendaIngressos.Domain.Entities;

namespace VendaIngressos.Domain.Interfaces
{
    public interface IProdutoDescontoRepository
    {
        Task<ProdutoDesconto> ObterPorCodigo(int codigo);

        Task<List<ProdutoDesconto>> ObterDescontosPorCodigoProduto(int codigoProduto);

        Task<List<ProdutoDesconto>> ObterTodos();

        Task Adicionar(ProdutoDesconto produtoDesconto);

        Task Atualizar(ProdutoDesconto produtoDesconto);

        Task Remover(int codigo);
    }
}
