using GCB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCB.Infraestrutura.ConfiguracoesEF
{
    public class ReferenciaConfiguracao : IEntityTypeConfiguration<Referencia>
    {
        public void Configure(EntityTypeBuilder<Referencia> builder)
        {
            builder.ToTable("Referencias");

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Ano)
                .HasColumnName("AnoReferencia")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Mes)
                .HasColumnName("MesReferencia")
                .HasConversion<string>()
                .IsRequired();

            builder.OwnsOne(x => x.TotalDepositado, x => {

                x.Ignore(c => c.Sigla);
                x.Ignore(c => c.Simbolo);

                x.Property(s => s.Valor)
                    .HasPrecision(10, 2)
                    .HasColumnName("TotalDepositado")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.TotalRetirado, x => {

                x.Ignore(c => c.Sigla);
                x.Ignore(c => c.Simbolo);

                x.Property(s => s.Valor)
                    .HasPrecision(10, 2)
                    .HasColumnName("TotalRetirado")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.Saldo, x => {

                x.Ignore(c => c.Sigla);
                x.Ignore(c => c.Simbolo);

                x.Property(s => s.Valor)
                    .HasPrecision(10, 2)
                    .HasColumnName("Saldo")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.DiferencaSaldoAnterior, x => {

                x.Ignore(c => c.Sigla);
                x.Ignore(c => c.Simbolo);

                x.Property(s => s.Valor)
                    .HasPrecision(10, 2)
                    .HasColumnName("DiferencaSaldoAnterior")
                    .IsRequired();
            });

            builder.HasKey(x => x.Id);

            builder.HasAlternateKey("Ano", "Mes");
        }
    }
}
