using GCB.Comum.Excecoes;
using GCB.Dominio.EventosDominio;
using GCB.Dominio.Repositorios;
using Hangfire;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GCB.BackgroundTasks.Jobs
{
    public interface ICalcularDiferencaSaldoReferenciaJob
    {
        Task RunAtTimeOf(DateTime now);
    }

    public class CalcularDiferencaSaldoReferenciaJob : ICalcularDiferencaSaldoReferenciaJob
    {
        private readonly ILogger<AdicionarReferenciaJob> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediator mediator;

        public CalcularDiferencaSaldoReferenciaJob(
            ILogger<AdicionarReferenciaJob> logger,
            IUnitOfWork unitOfWork,
            IMediator mediator
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await RunAtTimeOf(DateTime.Now);
        }

        public async Task RunAtTimeOf(DateTime now)
        {
            logger.LogInformation("Calculo Diferença Saldo Job Iniciado...");

            try
            {
                logger.LogInformation("Publicando referência para cálculo...");

                await mediator.Publish(new CalcularDiferencaSaldoDomainEvent());

                await unitOfWork.SaveChanges();

                logger.LogInformation("Calculo Diferença Saldo Job Completo...");
            }
            catch (ValidationException ve)
            {
                logger.LogInformation("Não foi possivel realizar o cálculo...");

                foreach (var error in ve.Errors)
                    logger.LogInformation("{Key} - {Value}", error.Key, error.Value);                
            }
            catch
            {
                throw;
            }
        }
    }
}
