using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendaIngressos.Application.DTOs.Produto;
using VendaIngressos.Application.Interfaces;
using VendaIngressos.Domain.Entities;

namespace VendaIngressos.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProdutoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProdutoReadDto> ObterProdutoPorCodigoAsync(int codigo)
        {
            var produto = await _unitOfWork.Produtos.ObterPorCodigoAsync(codigo);
            if (produto == null)
            {
                return null;
            }

            return _mapper.Map<ProdutoReadDto>(produto);
        }


        public async Task<List<ProdutoReadDto>> ObterTodosProdutosAsync()
        {
            var produtos = await _unitOfWork.Produtos.ObterTodosAsync();
            return _mapper.Map<List<ProdutoReadDto>>(produtos);
        }

        public async Task AdicionarProdutoAsync(ProdutoCreateDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await _unitOfWork.Produtos.AdicionarAsync(produto);
            await _unitOfWork.CompletarAsync();
        }

        public async Task AtualizarProdutoAsync(int codigo, ProdutoUpdateDto produtoDto)
        {
            var produtoExistente = await _unitOfWork.Produtos.ObterPorCodigoAsync(codigo);
            if (produtoExistente == null)
            {
                return;
            }

            _mapper.Map(produtoDto, produtoExistente);
            await _unitOfWork.Produtos.AtualizarAsync(produtoExistente);
            await _unitOfWork.CompletarAsync();
        }

        public async Task RemoverProdutoAsync(int codigo)
        {
            var produtoExistente = await _unitOfWork.Produtos.ObterPorCodigoAsync(codigo);

            if (produtoExistente == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }
            await _unitOfWork.Produtos.RemoverAsync(produtoExistente);
            await _unitOfWork.CompletarAsync();
        }
    }
}
