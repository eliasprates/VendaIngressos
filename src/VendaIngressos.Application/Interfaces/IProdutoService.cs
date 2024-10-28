using System.Collections.Generic;
using System.Threading.Tasks;
using VendaIngressos.Application.DTOs.Produto;
using VendaIngressos.Application.DTOs.ProdutoReadDto;
using VendaIngressos.Domain.Entities;

namespace VendaIngressos.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoReadDto> ObterProdutoPorCodigoAsync(int codigo);

        Task<List<ProdutoReadDto>> ObterTodosProdutosAsync();

        Task AdicionarProdutoAsync(ProdutoCreateDto produtoDto);

        Task AtualizarProdutoAsync(int codigo, ProdutoUpdateDto produto);

        Task RemoverProdutoAsync(int codigo);
    }
}
