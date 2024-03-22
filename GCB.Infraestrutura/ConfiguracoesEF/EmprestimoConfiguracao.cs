using GCB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCB.Infraestrutura.ConfiguracoesEF
{
    public class EmprestimoConfiguracao : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimos");
            
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Devedor)
                .IsRequired();

            builder.Property(x => x.DataEmprestimo)
                .IsRequired();

            builder.OwnsOne(x => x.ValorEmprestimo, x => {
                
                x.Ignore(c => c.Sigla);
                x.Ignore(c => c.Simbolo);

                x.Property(s => s.Valor)
                    .HasPrecision(10, 2)
                    .HasColumnName("ValorEmprestimo")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.ValorPrevisto, x => {

                x.Ignore(c => c.Sigla);
                x.Ignore(c => c.Simbolo);

                x.Property(s => s.Valor)
                    .HasPrecision(10, 2)
                    .HasColumnName("ValorPrevisto")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.ValorPago, x => {

                x.Ignore(c => c.Sigla);
                x.Ignore(c => c.Simbolo);

                x.Property(s => s.Valor)
                    .HasPrecision(10, 2)
                    .HasColumnName("ValorPago")
                    .IsRequired();
            });

            builder.HasMany(c => c.Pagamentos)
                .WithOne()
                .HasForeignKey(p => p.EmprestimoId);

            builder.Navigation(b => b.Pagamentos);

            builder.HasKey(x => x.Id);
        }
    }
}
