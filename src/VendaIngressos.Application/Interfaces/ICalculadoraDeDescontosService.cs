using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaIngressos.Domain.Entities;

namespace VendaIngressos.Application.Interfaces
{
    public interface ICalculadoraDeDescontosService
    {
        public Task<decimal> CalcularDesconto(int codigoProduto, int quantidade);

    }
}
