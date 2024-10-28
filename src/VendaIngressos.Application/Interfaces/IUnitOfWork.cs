using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaIngressos.Domain.Interfaces;

namespace VendaIngressos.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProdutoRepository Produtos { get; }
        IProdutoDescontoRepository ProdutoDescontos { get; }

        Task<int> CompletarAsync();
    }

}
