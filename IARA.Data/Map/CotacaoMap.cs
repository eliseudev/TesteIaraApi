using System;
using IARA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IARA.Data.Map
{
    public class CotacaoMap : IEntityTypeConfiguration<CotacaoEntitie>
    {
        public void Configure(EntityTypeBuilder<CotacaoEntitie> builder)
        {
            builder.ToTable("Cotacao");

            builder.HasKey(x => x.IdCotacao);

            builder.Property(x => x.IdCotacao)
                .IsRequired();

            builder.Property(x => x.CnpjCliente)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(x => x.CnpjFornecedor)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(x => x.NumeroCotacao)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.DataCotacao)
                .IsRequired();

            builder.Property(x => x.DataEntregaCotacao)
                .IsRequired();

            builder.Property(x => x.Endereco)
                .HasColumnType("varchar(70)");

            builder.Property(x => x.Complemento)
                .HasColumnType("varchar(25)");

            builder.Property(x => x.Bairro)
                .HasColumnType("varchar(30)");

            builder.Property(x => x.Cep)
                .HasColumnType("varchar(12)");

            builder.Property(x => x.Cidade)
                .HasColumnType("varchar(30)");

            builder.Property(x => x.Estado)
                .HasColumnType("varchar(30)");

            builder.Property(x => x.Observacao)
                .HasColumnType("varchar(200)");

            builder.HasMany(x => x.CotacaoItem)
                .WithOne(x => x.cotacao);

        }
    }
}

