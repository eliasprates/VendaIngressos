using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaIngressos.Application.Interfaces;
using VendaIngressos.Domain.Entities;
using VendaIngressos.Domain.Interfaces;

namespace VendaIngressos.Application.Services
{
    public class CalculadoraDeDescontosService : ICalculadoraDeDescontosService
    {
        private readonly IProdutoDescontoRepository _produtoDescontoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public CalculadoraDeDescontosService(IProdutoDescontoRepository produtoDescontoRepository, IProdutoRepository produtoRepository)
        {
            _produtoDescontoRepository = produtoDescontoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<decimal> CalcularDesconto(int codigoProduto, int quantidade)
        {
            decimal valorTotal = 0;

            // Obtém o produto pelo código
            var produto = await _produtoRepository.ObterPorCodigoAsync(codigoProduto);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            // Obtém a lista de descontos associada ao código do produto
            var descontos = await _produtoDescontoRepository.ObterDescontosPorCodigoProduto(codigoProduto);

            // Verifica se não há descontos cadastrados
            if (descontos == null || descontos.Count == 0)
            {
                // Não há descontos cadastrados, o valor total é quantidade * valor do produto
                valorTotal = quantidade * produto.Valor;
                return valorTotal;
            }

            // Ordena os descontos pela quantidade mínima de forma crescente
            var descontosOrdenados = descontos.OrderBy(d => d.Quantidade).ToList();

            // Verifica se a quantidade é menor que a quantidade mínima para o desconto
            if (quantidade < descontosOrdenados.First().Quantidade)
            {
                // Quantidade não atende o requisito mínimo para desconto
                valorTotal = quantidade * produto.Valor;
                return valorTotal;
            }

            else
            {
                int quantidadeFaixaAtual = 1;
                decimal valorFaixaAtual = produto.Valor;

                for (int quantidadeCalculada = 0; quantidadeCalculada < quantidade;)
                {
                    // Pega a faixa correspondente
                    var faixaDesconto = descontosOrdenados.FirstOrDefault(d => d.Quantidade == quantidadeCalculada);

                    // Se encontrar uma faixa, atualiza os valores, senão mantém os atuais
                    if (faixaDesconto != null)
                    {
                        quantidadeFaixaAtual = faixaDesconto.Quantidade;
                        valorFaixaAtual = faixaDesconto.Valor;
                    }

                    // Adiciona o valor ao total e incrementa a quantidade calculada
                    valorTotal += valorFaixaAtual;                  
                    quantidadeCalculada++;
                }

                return valorTotal;
            }


        }
    }
}
