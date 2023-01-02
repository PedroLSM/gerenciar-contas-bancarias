using GCB.Dominio.EventosDominio;
using GCB.Dominio.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.EventosDominio.ReferenciaCriada
{
    public class CalcularDiferencaComMesAnteriorDomainEventHandler : INotificationHandler<CalcularDiferencaSaldoDomainEvent>
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

        public Task Handle(CalcularDiferencaSaldoDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Realizando calcula da diferença do saldo com o mês anterior.");

            var referencias = unitOfWork.Referencia.ObterUltimasReferenciasParaCalculo();

            if (referencias.Atual is null || referencias.Anterior is null)
            {
                logger.LogInformation("Ainda não possui parametros suficientes para realizar o calculo.");
                return Task.CompletedTask;
            }

            var ref1 = referencias.Anterior;
            var ref2 = referencias.Atual;

            logger.LogInformation($"Referência Anterior |  [{ref1.Id} - {ref1.Mes}/{ref1.Ano}] [R$ {ref1.Saldo.Valor}].");
            logger.LogInformation($"Referência Atual    |  [{ref2.Id} - {ref2.Mes}/{ref2.Ano}] [R$ {ref2.Saldo.Valor}].");

            ref2.CalcularDiferenciaSaldoAnterior(ref1);

            unitOfWork.Referencia.Update(ref2);

            logger.LogInformation("Diferença com o saldo da refêrencia anterior calculada.");

            return Task.CompletedTask;
        }
    }
}
