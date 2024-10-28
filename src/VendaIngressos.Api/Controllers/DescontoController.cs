using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VendaIngressos.Application.Interfaces;

namespace VendaIngressos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DescontoController : ControllerBase
    {
        private readonly ICalculadoraDeDescontosService _calculadoraDeDescontosService;

        public DescontoController(ICalculadoraDeDescontosService calculadoraDeDescontosService)
        {
            _calculadoraDeDescontosService = calculadoraDeDescontosService;
        }

        [HttpGet("calcular")]
        public async Task<IActionResult> CalcularDesconto([FromQuery] int codigoProduto, [FromQuery] int quantidade)
        {
            if (codigoProduto <= 0 || quantidade <= 0)
            {
                return BadRequest("Código do produto e quantidade devem ser maiores que zero.");
            }

            try
            {
                var valorTotal = await _calculadoraDeDescontosService.CalcularDesconto(codigoProduto, quantidade);
                return Ok(new { CodigoProduto = codigoProduto, Quantidade = quantidade, ValorTotal = valorTotal });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao calcular desconto: {ex.Message}");
            }
        }
    }
}
