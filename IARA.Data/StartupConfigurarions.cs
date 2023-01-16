using System;
using IARA.Data.Repositories;
using IARA.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IARA.Data
{
	public static class StartupConfigurarions
	{
		public static IServiceCollection AddRepositoriesDependencies(this IServiceCollection services)
        {
			services.AddScoped<ICotacaoRepository, CotacaoRepositoty>();
			services.AddScoped<IItemCotacaoRepository, ItemCotacaoRepository>();
			return services;
		}

		public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<IaraContext>(options => options.UseSqlServer(configuration.GetConnectionString("IaraDbContection")));
			return services;
		}
	}
}

