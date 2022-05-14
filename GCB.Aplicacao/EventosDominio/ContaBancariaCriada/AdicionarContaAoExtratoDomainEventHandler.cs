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

namespace GCB.Aplicacao.EventosDominio.ContaBancariaCriada
{
    public class AdicionarContaAoExtratoDomainEventHandler : INotificationHandler<ContaBancariaCriadaDomainEvent>
    {
        private readonly ILogger<AdicionarContaAoExtratoDomainEventHandler> logger;
        private readonly IUnitOfWork unitOfWork;

        public AdicionarContaAoExtratoDomainEventHandler(
            ILogger<AdicionarContaAoExtratoDomainEventHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Task Handle(ContaBancariaCriadaDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Conta com o Id: {Id} foi criada, realizando criação de extrato", notification.Id);

            var ultimaReferencia = unitOfWork.Referencia.GetLast();

            var extrato = new Extrato(notification.Id, ultimaReferencia.Id, new Real(notification.SaldoAtual.Valor));

            unitOfWork.Extrato.Add(extrato);

            logger.LogInformation("Extrato criado com o Id: {Id}", extrato.Id);
            
            return Task.CompletedTask;
        }
    }
}
