using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaIngressos.Application.DTOs.Produto;

namespace VendaIngressos.Application.Validators.Produto
{
    public class ProdutoCreateValidator : AbstractValidator<ProdutoCreateDto>
    {
        public ProdutoCreateValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(50).WithMessage("O nome do produto deve ter no máximo 50 caracteres.");

            RuleFor(p => p.Valor)
                .GreaterThan(0).WithMessage("O valor do produto deve ser maior que zero.")
                .Must(valor => valor == decimal.Round(valor, 2))
                .WithMessage("O valor do produto deve ter no máximo 2 casas decimais.")
                .Must(valor => valor.ToString("F2").Length <= 12)
                .WithMessage("O valor do produto deve ter no máximo 10 dígitos, incluindo 2 casas decimais.");
        }
    }
}
