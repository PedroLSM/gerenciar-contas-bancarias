using GCB.Dominio.EventosDominio;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.EventosDominio.DepositoBancarioRealizado
{
    public class AdicionarDepositoAReferenciaDomainEventHandler : INotificationHandler<DepositoBancarioRealizadoDomainEvent>
    {
        private readonly ILogger<AdicionarDepositoAReferenciaDomainEventHandler> logger;
        private readonly IUnitOfWork unitOfWork;

        public AdicionarDepositoAReferenciaDomainEventHandler(
            ILogger<AdicionarDepositoAReferenciaDomainEventHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(DepositoBancarioRealizadoDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deposito com o Id: {Id} foi criada, realizando deposito na referencia com o Id: {ReferenciaId}", notification.DepositoId, notification.ReferenciaId);

            var referencia = unitOfWork.Referencia.GetSingle(notification.ReferenciaId);

            referencia.AdicionarDeposito(new Real(notification.Valor.Valor));

            unitOfWork.Referencia.Update(referencia);

            logger.LogInformation("Deposito com o Id: {Id} foi realizado na referência com o Id: {ReferenciaId}", notification.DepositoId, notification.ReferenciaId);

            return Task.CompletedTask;
        }
    }
}
