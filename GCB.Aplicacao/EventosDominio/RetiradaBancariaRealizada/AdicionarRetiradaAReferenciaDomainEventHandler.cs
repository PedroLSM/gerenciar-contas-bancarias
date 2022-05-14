using GCB.Comum.Excecoes;
using GCB.Dominio.Entidades;
using GCB.Dominio.EventosDominio;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.EventosDominio.RetiradaBancariaRealizada
{
    public class AdicionarRetiradaAReferenciaDomainEventHandler : INotificationHandler<RetiradaBancariaRealizadaDomainEvent>
    {
        private readonly ILogger<AdicionarRetiradaAReferenciaDomainEventHandler> logger;
        private readonly IUnitOfWork unitOfWork;

        public AdicionarRetiradaAReferenciaDomainEventHandler(
            ILogger<AdicionarRetiradaAReferenciaDomainEventHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(RetiradaBancariaRealizadaDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retirada com o Id: {Id} foi criada, realizando retirada na referência com o Id: {ReferenciaId}", notification.RetiradaId, notification.ReferenciaId);

            var referencia = unitOfWork.Referencia.GetSingle(notification.ReferenciaId);

            referencia.AdicionarRetirada(new Real(notification.Valor.Valor));

            unitOfWork.Referencia.Update(referencia);

            logger.LogInformation("Retirada com o Id: {Id} foi realizado na referência com o Id: {ReferenciaId}", notification.RetiradaId, notification.ReferenciaId);
            
            return Task.CompletedTask;
        }
    }
}
