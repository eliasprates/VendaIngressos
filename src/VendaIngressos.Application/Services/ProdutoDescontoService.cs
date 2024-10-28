using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendaIngressos.Application.DTOs.ProdutoReadDto;
using VendaIngressos.Application.Interfaces;
using VendaIngressos.Domain.Entities;

namespace VendaIngressos.Application.Services
{
    public class ProdutoDescontoService : IProdutoDescontoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProdutoDescontoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProdutoDescontoReadDto>> ObterTodosDescontosAsync()
        {
            var descontos = await _unitOfWork.ProdutoDescontos.ObterTodos();
            return _mapper.Map<List<ProdutoDescontoReadDto>>(descontos);
        }

        public async Task<List<ProdutoDescontoReadDto>> ObterDescontosPorCodigoProdutoAsync(int codigoProduto)
        {
            var descontos = await _unitOfWork.ProdutoDescontos.ObterDescontosPorCodigoProduto(codigoProduto);
            return _mapper.Map<List<ProdutoDescontoReadDto>>(descontos);
        }

        public async Task AdicionarDescontoAsync(ProdutoDescontoCreateDto produtoDescontoDto)
        {
            var produtoDesconto = _mapper.Map<ProdutoDesconto>(produtoDescontoDto);
            await _unitOfWork.ProdutoDescontos.Adicionar(produtoDesconto);
            await _unitOfWork.CompletarAsync();
        }

        public async Task AtualizarDescontoAsync(int codigo, ProdutoDescontoUpdateDto produtoDescontoDto)
        {
            var descontoExistente = await _unitOfWork.ProdutoDescontos.ObterPorCodigo(codigo);
            if (descontoExistente == null)
            {
                return;
            }
            _mapper.Map(produtoDescontoDto, descontoExistente);
            await _unitOfWork.ProdutoDescontos.Atualizar(descontoExistente);
            await _unitOfWork.CompletarAsync();
        }

        public async Task RemoverDescontoAsync(int codigo)
        {
            await _unitOfWork.ProdutoDescontos.Remover(codigo);
            await _unitOfWork.CompletarAsync();
        }
    }
}
