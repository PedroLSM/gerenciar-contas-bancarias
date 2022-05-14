using GCB.Comum.Excecoes;
using GCB.Dominio.Entidades;
using GCB.Dominio.EventosDominio;
using GCB.Dominio.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.EventosDominio.ContaBancariaCriada
{
    public class AdicionarSaldoContaNaUltimaReferencia : INotificationHandler<ContaBancariaCriadaDomainEvent>
    {
        private readonly ILogger<AdicionarSaldoContaNaUltimaReferencia> logger;
        private readonly IUnitOfWork unitOfWork;

        public AdicionarSaldoContaNaUltimaReferencia(
            ILogger<AdicionarSaldoContaNaUltimaReferencia> logger,
            IUnitOfWork unitOfWork
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(ContaBancariaCriadaDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Conta com o Id: {Id} foi criada, realizando adição do saldo da conta no total da ultima referência", notification.Id);

            var ultimaReferencia = unitOfWork.Referencia.GetLast();

            var contaBancaria = unitOfWork.ContaBancaria.GetSingle(notification.Id);

            ultimaReferencia.AdicionarSaldo(contaBancaria.SaldoAtual);

            unitOfWork.Referencia.Update(ultimaReferencia);

            logger.LogInformation("Saldo da referencia com o Id: {Id} foi atualizado", ultimaReferencia.Id);
            
            return Task.CompletedTask;
        }
    }
}