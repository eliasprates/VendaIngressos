using System.Collections.Generic;
using System.Threading.Tasks;
using VendaIngressos.Application.DTOs.ProdutoReadDto; 

namespace VendaIngressos.Application.Interfaces
{
    public interface IProdutoDescontoService
    {
        Task<List<ProdutoDescontoReadDto>> ObterTodosDescontosAsync();
        Task<List<ProdutoDescontoReadDto>> ObterDescontosPorCodigoProdutoAsync(int codigoProduto);

        Task AdicionarDescontoAsync(ProdutoDescontoCreateDto produtoDescontoDto);

        Task AtualizarDescontoAsync(int codigo, ProdutoDescontoUpdateDto produtoDescontoDto);

        Task RemoverDescontoAsync(int codigo);
    }
}
