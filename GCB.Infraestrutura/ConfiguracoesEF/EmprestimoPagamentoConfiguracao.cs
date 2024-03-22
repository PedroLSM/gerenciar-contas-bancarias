using GCB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCB.Infraestrutura.ConfiguracoesEF
{
    public class EmprestimoPagamentoConfiguracao : IEntityTypeConfiguration<EmprestimoPagamento>
    {
        public void Configure(EntityTypeBuilder<EmprestimoPagamento> builder)
        {
            builder.ToTable("EmprestimoPagamentos");
            
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.DataPagamento)
                .IsRequired();

            builder.Property(x => x.EmprestimoId)
                .IsRequired();

            builder.OwnsOne(x => x.ValorPago, x => {
                x.Ignore(c => c.Sigla);
                x.Ignore(c => c.Simbolo);

                x.Property(s => s.Valor)
                    .HasPrecision(10, 2)
                    .HasColumnName("ValorPago")
                    .IsRequired();
            });

            builder.HasKey(x => x.Id);
        }
    }
}
