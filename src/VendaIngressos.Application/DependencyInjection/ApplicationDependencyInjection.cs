using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VendaIngressos.Application.DTOs;
using VendaIngressos.Application.DTOs.Produto;
using VendaIngressos.Application.DTOs.ProdutoReadDto;
using VendaIngressos.Application.Interfaces;
using VendaIngressos.Application.Services;
using VendaIngressos.Application.Validators;
using VendaIngressos.Application.Validators.Produto;
using VendaIngressos.Application.Validators.ProdutoDesconto;

namespace VendaIngressos.Application.DependencyInjection
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoDescontoService, ProdutoDescontoService>();
            services.AddScoped<ICalculadoraDeDescontosService, CalculadoraDeDescontosService>();

            services.AddTransient<IValidator<ProdutoCreateDto>, ProdutoCreateValidator>();
            services.AddTransient<IValidator<ProdutoUpdateDto>, ProdutoUpdateValidator>();

            services.AddTransient<IValidator<ProdutoDescontoCreateDto>, ProdutoDescontoCreateValidator>();
            services.AddTransient<IValidator<ProdutoDescontoUpdateDto>, ProdutoDescontoUpdateValidator>();

            return services;
        }
    }


}
