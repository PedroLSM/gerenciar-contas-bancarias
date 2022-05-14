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

namespace GCB.Aplicacao.EventosDominio.ReferenciaCriada
{
    public class CriarNovosExtratosDomainEventHandler : INotificationHandler<ReferenciaCriadaDomainEvent>
    {
        private readonly ILogger<CriarNovosExtratosDomainEventHandler> logger;
        private readonly IUnitOfWork unitOfWork;

        public CriarNovosExtratosDomainEventHandler(
            ILogger<CriarNovosExtratosDomainEventHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(ReferenciaCriadaDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Referência com o Id: {Id} foi criada, realizando criação dos novos extratos", notification.ReferenciaId);
            
            var contasBancarias = unitOfWork.ContaBancaria.GetAll(cb => cb.Ativa);

            foreach (var contaBancaria in contasBancarias)
            {
                var extrato = new Extrato(contaBancaria.Id, notification.ReferenciaId, new Real(contaBancaria.SaldoAtual.Valor));
                unitOfWork.Extrato.Add(extrato);
            }

            return Task.CompletedTask;
        }
    }
}
