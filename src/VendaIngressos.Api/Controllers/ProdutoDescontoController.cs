using Microsoft.AspNetCore.Mvc;
using VendaIngressos.Application.DTOs.ProdutoReadDto; // Atualize para o namespace correto dos novos DTOs
using VendaIngressos.Application.Interfaces;

namespace VendaIngressos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoDescontoController : ControllerBase
    {
        private readonly IProdutoDescontoService _produtoDescontoService;

        public ProdutoDescontoController(IProdutoDescontoService produtoDescontoService)
        {
            _produtoDescontoService = produtoDescontoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosDescontos()
        {
            var descontos = await _produtoDescontoService.ObterTodosDescontosAsync();
            return Ok(descontos);
        }

        [HttpGet("{codigoProduto}")]
        public async Task<IActionResult> ObterDescontosPorProduto(int codigoProduto)
        {
            var descontos = await _produtoDescontoService.ObterDescontosPorCodigoProdutoAsync(codigoProduto);
            return Ok(descontos);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ProdutoDescontoCreateDto descontoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _produtoDescontoService.AdicionarDescontoAsync(descontoDto);
            return CreatedAtAction(nameof(ObterDescontosPorProduto), new { codigoProduto = descontoDto.ProdutoCodigo }, descontoDto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Atualizar(int codigo, [FromBody] ProdutoDescontoUpdateDto descontoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _produtoDescontoService.AtualizarDescontoAsync(codigo, descontoDto);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Remover(int codigo)
        {
            await _produtoDescontoService.RemoverDescontoAsync(codigo);
            return NoContent();
        }
    }
}
