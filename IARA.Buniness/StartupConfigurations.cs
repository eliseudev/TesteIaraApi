using System;
using IARA.Buniness.CotacaoBusiness.SalvarCotacao;
using IARA.Buniness.Services.ViaCep;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IARA.Buniness
{
	public static class StartupConfigurations
	{
		public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
		{
			services.AddMediatR(typeof(AdicionarCotacaoCommandHandler).Assembly);
			return services;
		}

        public static IServiceCollection ConfigureViaCep(this IServiceCollection services)
        {
            services.AddScoped<IViaCepService, ViaCepService>();
            return services;
        }
    }
}

