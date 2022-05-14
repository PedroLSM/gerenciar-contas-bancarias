using GCB.Dominio.Enums;
using GCB.Dominio.EventosDominio;
using GCB.Dominio.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.EventosDominio.ReferenciaCriada
{
    public class CalcularDiferencaComMesAnteriorDomainEventHandler : INotificationHandler<ReferenciaCriadaDomainEvent>
    {
        private readonly ILogger<CalcularDiferencaComMesAnteriorDomainEventHandler> logger;
        private readonly IUnitOfWork unitOfWork;

        public CalcularDiferencaComMesAnteriorDomainEventHandler(
            ILogger<CalcularDiferencaComMesAnteriorDomainEventHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(ReferenciaCriadaDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Referência com o Id: {Id} foi criada, realizando calcula da diferença do saldo com o mês anterior.", notification.ReferenciaId);
            
            var referencias = unitOfWork.Referencia.GetAll();

            if (!referencias.Any())
            {
                logger.LogInformation("Ainda não possui parametros suficientes para realizar o calculo.");
                return Task.CompletedTask;
            }

            var (mes1, ano1) = notification.MesReferencia - 1 <= 0 ? (notification.MesReferencia + 11, notification.AnoReferencia - 1) : (notification.MesReferencia - 1, notification.AnoReferencia);
            var (mes2, ano2) = notification.MesReferencia - 2 <= 0 ? (notification.MesReferencia + 10, notification.AnoReferencia - 1) : (notification.MesReferencia - 2, notification.AnoReferencia);

            var ultimasReferencias = referencias
                .Where(r => (mes1 == r.Mes && ano1 == r.Ano) || (mes2 == r.Mes && ano2 == r.Ano));

            if (!ultimasReferencias.Any())
            {
                logger.LogInformation("Ainda não possui parametros suficientes para realizar o calculo.");
                return Task.CompletedTask;
            }

            var ref1 = ultimasReferencias.First();
            var ref2 = ultimasReferencias.Last();

            ref2.CalcularDiferenciaSaldoAnterior(ref1);

            unitOfWork.Referencia.Update(ref2);

            logger.LogInformation("Diferença com o saldo da refêrencia anterior calculada.");

            return Task.CompletedTask;
        }
    }
}
