using System.Collections.Generic;
using System.Threading.Tasks;
using VendaIngressos.Domain.Entities;

namespace VendaIngressos.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> ObterPorCodigoAsync(int codigo);

        Task AdicionarAsync(Produto produto);

        Task AtualizarAsync(Produto produto);

        Task RemoverAsync(Produto produto);

        Task<IEnumerable<Produto>> ObterTodosAsync();
    }
}
