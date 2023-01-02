using GCB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCB.Infraestrutura.ConfiguracoesEF
{
    public class RetiradaBancariaConfiguracao : IEntityTypeConfiguration<RetiradaBancaria>
    {
        public void Configure(EntityTypeBuilder<RetiradaBancaria> builder)
        {
            builder.ToTable("RetiradasBancarias");

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.ExtratoId)
                .IsRequired();

            builder.Property(x => x.DataRegistro)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasMaxLength(100)
                .IsRequired();

            builder.OwnsOne(x => x.Valor, x => {

                x.Ignore(c => c.Sigla);
                x.Ignore(c => c.Simbolo);

                x.Property(s => s.Valor)
                    .HasPrecision(10, 2)
                    .HasColumnName("ValorRetirado")
                    .IsRequired();
            });

            builder.HasKey(x => x.Id);
        }
    }
}
