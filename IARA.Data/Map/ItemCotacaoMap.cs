using System;
using IARA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IARA.Data.Map
{
    public class ItemCotacaoMap : IEntityTypeConfiguration<ItemCotacaoEntitie>
    {
        public void Configure(EntityTypeBuilder<ItemCotacaoEntitie> builder)
        {
            builder.ToTable("CotacaoItem");

            builder.HasKey(x => x.ItemCotacaoId);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.NumeroItem)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("decimal(19,2)");

            builder.Property(x => x.Quantidade)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Marca)
                .HasColumnType("varchar(30)");
        }
    }
}

