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
    public class AdicionarRetiradaAContaBancariaDomainEventHandler : INotificationHandler<RetiradaBancariaRealizadaDomainEvent>
    {
        private readonly ILogger<AdicionarRetiradaAContaBancariaDomainEventHandler> logger;
        private readonly IUnitOfWork unitOfWork;

        public AdicionarRetiradaAContaBancariaDomainEventHandler(
            ILogger<AdicionarRetiradaAContaBancariaDomainEventHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(RetiradaBancariaRealizadaDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retirada com o Id: {Id} foi criada, realizando retirada na conta com o Id: {ContaId}", notification.RetiradaId, notification.ContaBancariaId);

            var contaBancaria = unitOfWork.ContaBancaria.GetSingle(notification.ContaBancariaId);

            contaBancaria.AdicionarRetirada(new Real(notification.Valor.Valor));

            unitOfWork.ContaBancaria.Update(contaBancaria);

            logger.LogInformation("Retirada com o Id: {Id} foi realizado na conta com o Id: {ContaId}", notification.RetiradaId, notification.ContaBancariaId);

            return Task.CompletedTask;
        }
    }
}
