using GCB.Dominio.EventosDominio;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.EventosDominio.DepositoBancarioRealizado
{
    public class AdicionarDepositoAContaBancariaDomainEventHandler : INotificationHandler<DepositoBancarioRealizadoDomainEvent>
    {
        private readonly ILogger<AdicionarDepositoAContaBancariaDomainEventHandler> logger;
        private readonly IUnitOfWork unitOfWork;

        public AdicionarDepositoAContaBancariaDomainEventHandler(
            ILogger<AdicionarDepositoAContaBancariaDomainEventHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(DepositoBancarioRealizadoDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deposito com o Id: {Id} foi criada, realizando deposito na conta com o Id: {ContaId}", notification.DepositoId, notification.ContaBancariaId);

            var contaBancaria = unitOfWork.ContaBancaria.GetSingle(notification.ContaBancariaId);

            contaBancaria.AdicionarDeposito(new Real(notification.Valor.Valor));

            unitOfWork.ContaBancaria.Update(contaBancaria);

            logger.LogInformation("Deposito com o Id: {Id} foi realizado na conta com o Id: {ContaId}", notification.DepositoId, notification.ContaBancariaId);
            
            return Task.CompletedTask;
        }
    }
}
