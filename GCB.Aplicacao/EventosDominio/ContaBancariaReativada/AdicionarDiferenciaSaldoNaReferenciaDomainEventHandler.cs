using GCB.Comum.Excecoes;
using GCB.Dominio.Entidades;
using GCB.Dominio.EventosDominio;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.EventosDominio.ContaBancariaReativada
{
    public class AdicionarDiferenciaSaldoNaReferenciaDomainEventHandler : INotificationHandler<ContaBancariaReativadaDomainEvent>
    {
        private readonly ILogger<AdicionarDiferenciaSaldoNaReferenciaDomainEventHandler> logger;
        private readonly IUnitOfWork unitOfWork;

        public AdicionarDiferenciaSaldoNaReferenciaDomainEventHandler(
            ILogger<AdicionarDiferenciaSaldoNaReferenciaDomainEventHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(ContaBancariaReativadaDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Conta com o Id: {Id} foi reativada, realizando adição do saldo da conta no total da ultima referência", notification.ContaBancariaId);

            var ultimaReferencia = unitOfWork.Referencia.GetLast();

            ultimaReferencia.AdicionarSaldo(new Real(notification.DiferencaSaldoAnterior.Valor));

            unitOfWork.Referencia.Update(ultimaReferencia);

            logger.LogInformation("Saldo da referencia com o Id: {Id} foi atualizado", ultimaReferencia.Id);

            return Task.CompletedTask;
        }
    }
}
