using GCB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCB.Infraestrutura.ConfiguracoesEF
{
    public class ContaBancariaConfiguracao : IEntityTypeConfiguration<ContaBancaria>
    {
        public void Configure(EntityTypeBuilder<ContaBancaria> builder)
        {
            builder.ToTable("ContasBancarias");

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.NomeBanco)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.TipoConta)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.Ativa)
                .IsRequired();

            builder.OwnsOne(x => x.SaldoAtual, x => {

                x.Ignore(c => c.Sigla);
                x.Ignore(c => c.Simbolo);

                x.Property(s => s.Valor)
                    .HasPrecision(10, 2)
                    .HasColumnName("SaldoAtual")
                    .IsRequired();
            });

            builder.HasKey(x => x.Id);
        }
    }
}
