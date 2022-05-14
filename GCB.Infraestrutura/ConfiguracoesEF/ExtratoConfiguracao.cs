using GCB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCB.Infraestrutura.ConfiguracoesEF
{
    public class ExtratoConfiguracao : IEntityTypeConfiguration<Extrato>
    {
        public void Configure(EntityTypeBuilder<Extrato> builder)
        {
            builder.ToTable("Extratos");
            
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.ContaBancariaId)
                .IsRequired();

            builder.Property(x => x.ReferenciaId)
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

            builder.HasMany(c => c.DepositosBancarios)
                .WithOne();

            builder.Navigation(b => b.DepositosBancarios);

            builder.HasMany(c => c.RetiradasBancarias)
                .WithOne();

            builder.Navigation(b => b.RetiradasBancarias);

            builder.HasOne<ContaBancaria>()
                .WithMany()
                .HasForeignKey(p => p.ContaBancariaId);


            builder.HasOne<Referencia>()
                .WithMany()
                .HasForeignKey(p => p.ReferenciaId);

            builder.HasKey(x => x.Id);
        }
    }
}
