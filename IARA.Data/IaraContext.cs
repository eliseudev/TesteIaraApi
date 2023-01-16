using System;
using IARA.Data.Map;
using IARA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IARA.Data
{
	public class IaraContext : DbContext
	{
        public DbSet<CotacaoEntitie> Cotacao { get; set; }
        public DbSet<ItemCotacaoEntitie> ItemCotacao { get; set; }

        public IaraContext(DbContextOptions<IaraContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CotacaoMap());
			modelBuilder.ApplyConfiguration(new ItemCotacaoMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}

