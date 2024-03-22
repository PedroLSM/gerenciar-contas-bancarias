using GCB.Dominio.Entidades;
using GCB.Comum.Notificacoes;
using GCB.Infraestrutura.ConfiguracoesEF;
using Microsoft.EntityFrameworkCore;

namespace GCB.Infraestrutura
{
    public class GerenciarContasBancariasContext : DbContext
    {
        public GerenciarContasBancariasContext(DbContextOptions<GerenciarContasBancariasContext> options) 
            : base(options)
        {
        }

        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<DepositoBancario> DepositosBancarios { get; set; }
        public DbSet<RetiradaBancaria> RetiradasBancarias { get; set; }
        public DbSet<Extrato> Extratos { get; set; }
        public DbSet<Referencia> Referencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new ContaBancariaConfiguracao());
            modelBuilder.ApplyConfiguration(new DepositoBancarioConfiguracao());
            modelBuilder.ApplyConfiguration(new ReferenciaConfiguracao());
            modelBuilder.ApplyConfiguration(new RetiradaBancariaConfiguracao());
            modelBuilder.ApplyConfiguration(new ExtratoConfiguracao());
            modelBuilder.ApplyConfiguration(new EmprestimoConfiguracao());
            modelBuilder.ApplyConfiguration(new EmprestimoPagamentoConfiguracao());
        }
    }
}
