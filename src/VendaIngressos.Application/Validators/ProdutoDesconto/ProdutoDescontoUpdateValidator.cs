using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaIngressos.Application.DTOs.ProdutoReadDto;

namespace VendaIngressos.Application.Validators.ProdutoDesconto
{
    public class ProdutoDescontoUpdateValidator : AbstractValidator<ProdutoDescontoUpdateDto>
    {
        public ProdutoDescontoUpdateValidator()
        {
            RuleFor(d => d.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade mínima deve ser maior que zero.");

            RuleFor(d => d.Valor)
                .GreaterThan(0).WithMessage("O valor com desconto deve ser maior que zero.")
                .Must(valor => valor == decimal.Round(valor, 2))
                .WithMessage("O valor com desconto deve ter no máximo 2 casas decimais.")
                .Must(valor => valor.ToString("F2").Length <= 12)
                .WithMessage("O valor com desconto deve ter no máximo 10 dígitos, incluindo 2 casas decimais.");
        }
    }
}
