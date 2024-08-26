using Banco.Application.Interfaces;
using Banco.Application.Mappings;
using Banco.Application.Services;
using Banco.Domain.Interfaces;
using Banco.Infrastructure.Context;
using Banco.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banco.CrossCutting.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o DbContext com SQL Server usando a string de conexão do arquivo de configuração
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            

            // Configura injeção de dependência para repositórios e serviços
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IClienteService, ClienteService>();

            // Configura o AutoMapper com o perfil de mapeamento
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }

    }
}
