using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendaIngressos.Application.DTOs.Produto;
using VendaIngressos.Application.Interfaces;

namespace VendaIngressos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> ObterPorCodigo(int codigo)
        {
            var produto = await _produtoService.ObterProdutoPorCodigoAsync(codigo);
            if (produto == null)
                return NotFound("Produto não encontrado");
            var produtoDto = _mapper.Map<ProdutoReadDto>(produto);
            return Ok(produtoDto);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _produtoService.ObterTodosProdutosAsync();
            var produtosDto = _mapper.Map<List<ProdutoReadDto>>(produtos);
            return Ok(produtosDto);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ProdutoCreateDto produtoCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _produtoService.AdicionarProdutoAsync(produtoCreateDto);
            return CreatedAtAction(nameof(ObterPorCodigo), new { codigo = produtoCreateDto }, produtoCreateDto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Atualizar(int codigo, [FromBody] ProdutoUpdateDto produtoUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _produtoService.AtualizarProdutoAsync(codigo, produtoUpdateDto);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Remover(int codigo)
        {
            await _produtoService.RemoverProdutoAsync(codigo);
            return NoContent();
        }
    }
}
