using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaIngressos.Application.Interfaces;
using VendaIngressos.Domain.Interfaces;
using VendaIngressos.Infrastructure.Repositories;
using VendaIngressos.Infrastructure.UnitOfWork;

namespace VendaIngressos.Infrastructure.DependencyInjection
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoDescontoRepository, ProdutoDescontoRepository>();
            services.AddScoped<IUnitOfWork, MyUnitOfWork>();

            return services;
        }
    }
}
